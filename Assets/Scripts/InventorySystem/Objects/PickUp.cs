using InventorySystem.Objects;
using UnityEngine;

namespace InventorySystem
{
    public abstract class PickUp : MonoBehaviour
    {
        [SerializeField] private InventoryItemInfo info;
        public InventoryItem item { get; private set; }
        
        private void Awake()
        {
            item = new Shield(info);
        }
    }
}