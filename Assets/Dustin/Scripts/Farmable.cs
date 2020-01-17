using System;
using Dustin.Scripts.API;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Dustin.Scripts
{
    [CreateAssetMenu(fileName = "FarmableResource", menuName = "ScriptableObjects/FarmableResource")]
    public class FarmableResource : ScriptableObject
    {
        public string resourceName;
        public GameObject prefab;
        public CollectibleItem itemDrop;
        public int itemDropRate;
        public int hitsToFarm;
        public ToolType requiredTool;
        public int toolBoost;
    }
    
    public class Farmable : MonoBehaviour
    {
        [SerializeField]
        private FarmableResource farmableResource;
        [SerializeField]
        private float spawnRange = 0.3f;

        private Resource _resource;

        private void Start()
        {
            _resource = new Resource(
                farmableResource.resourceName,
                new Item(farmableResource.itemDrop.itemName),
                farmableResource.hitsToFarm,
                farmableResource.itemDropRate
                );
        }

        private void OnCollisionEnter(Collision other)
        {
            Debug.Log($"Collided with {other.gameObject.name} {other}");
            var tool = other.gameObject.GetComponent<Tool>();
            Debug.Log($"Tool: {tool}");
            if (tool == null) return;
            Debug.Log($"Hit {farmableResource.resourceName} with {tool.toolType}");
            var items = HandleHit(tool);
            if (items != null)
            {
                Debug.Log($"Farmed {farmableResource.resourceName}");
                DropItems(items);
                Destroy(gameObject);
            }
        }

        private Item[] HandleHit(Tool tool)
        {
            var toolBoost = (tool.toolType == farmableResource.requiredTool ? farmableResource.toolBoost : 0);
            var hits = 1 + tool.toolStrength * toolBoost;
            Item[] items = _resource.ExploitResource(hits);
            Debug.Log($"Hit {farmableResource.resourceName} {hits} time(s)");
            return items;
        }

        private void DropItems(Item[] items)
        {
            Debug.Log($"Dropping {items.Length} {farmableResource.itemDrop.itemName}(s)");
            
            // TODO: Actually spawn items from the item class, not the farmable resource class
            for (var i = 0; i < items.Length; i++)
            {
                Vector3 spawnPosition = transform.position;
                spawnPosition.x += Random.Range(-spawnRange, spawnRange);
                spawnPosition.y += Random.Range(-spawnRange, spawnRange);
                spawnPosition.z = 1f + Random.Range(-spawnRange, spawnRange);
                Instantiate(farmableResource.itemDrop.prefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
