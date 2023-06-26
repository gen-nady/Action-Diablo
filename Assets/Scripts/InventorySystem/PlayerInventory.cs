using System;
using InventorySystem.UI;
using UnityEngine;
using Zenject;

namespace InventorySystem
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private int _inventoryCapacity = 14;
        private InventoryWithSlots inventory;
        private UIInventory _uiInventory;

        [Inject]
        private void Construct(UIInventory uiInventory)
        {
            _uiInventory = uiInventory;
        }
        private void Awake()
        {
            inventory = new InventoryWithSlots(_inventoryCapacity);
            _uiInventory.SetInventory(inventory);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PickUp>(out var pickUp))
            {
                inventory.TryToAdd(this, pickUp.item);
                Destroy(pickUp.gameObject);
            }
        }
    }
}