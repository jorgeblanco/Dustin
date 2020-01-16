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
        [SerializeField] private CollectibleItem collectibleItem;

        private void Start()
        {
            Item = new Item(collectibleItem.itemName);
            Item.OnCollected += OnCollected;
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
