using System.Collections;
using Dustin.Scripts.API;
using UnityEngine;

namespace Dustin.Scripts
{
    [CreateAssetMenu(fileName = "CollectibleItem", menuName = "ScriptableObjects/CollectibleItem")]
    public class CollectibleItem : ScriptableObject
    {
        public string itemName;
        public GameObject prefab;
    }

    public class Collectible : MonoBehaviour
    {
        public Item Item { get; private set;  }
        public bool CanCollect { get; private set;  }
        [SerializeField] private CollectibleItem collectibleItem;
        
        private const float CollectCooldownTime = 3f;

        private void Start()
        {
            Item = new Item(collectibleItem.itemName);
            Item.OnCollected += OnCollected;
            CanCollect = false;
            StartCoroutine(CollectCooldown());
        }

        IEnumerator CollectCooldown()
        {
            yield return new WaitForSeconds(CollectCooldownTime);
            CanCollect = true;
        }

        private void OnCollected(string itemName)
        {
            Debug.Log($"Collected: {itemName}");
            
            // TODO: Add "collected" SFX/VFX
            // TODO: Pool objects
            Destroy(gameObject);
        }
    }
}
