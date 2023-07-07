using InventorySystem;
using InventorySystem.Objects;
using UnityEngine;

namespace ItemsSystem.Items.World
{
    public class SimpleSword : MonoBehaviour
    {
        [SerializeField] private InventoryItemInfo _info;
        public InventoryItemInfo Info => _info;
    }
}