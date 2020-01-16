using Dustin.Scripts.API;
using UnityEngine;

namespace Dustin.Scripts
{
    [RequireComponent(typeof(Collider))]
    public class Collect : MonoBehaviour
    {
        private Inventory _inventory;

        private void Start()
        {
            _inventory = Inventory.Instance;
        }

        private void OnTriggerEnter(Collider other)
        {
            var collectible = other.GetComponent<Collectible>();
            if (collectible == null)
            {
                return;
            }

            _inventory.CollectItem(collectible.Item);
            
            Debug.Log($"Your inventory: {_inventory.GetItemsNamesAsString()}");

        }
    }
}
