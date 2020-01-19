using Dustin.Scripts.API;
using UnityEngine;

namespace Dustin.Scripts
{
    [RequireComponent(typeof(Collider))]
    public class Collect : MonoBehaviour
    {
        [SerializeField] private DebugText debugText;
        private Inventory _inventory;

        private void Start()
        {
            _inventory = Inventory.Instance;
        }

        private void OnTriggerEnter(Collider other)
        {
            var collectible = other.GetComponent<Collectible>();
            if (collectible == null || !collectible.CanCollect)
            {
                return;
            }

            _inventory.CollectItem(collectible.Item);
            
            Debug.Log($"Your inventory: {_inventory.GetItemsNamesAsString()}");
            debugText.SetText($"Your inventory: {_inventory.GetItemsNamesAsString()}");

        }
    }
}
