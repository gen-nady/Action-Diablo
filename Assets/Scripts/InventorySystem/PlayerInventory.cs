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
        private WorldInfoUI _worldInfoUI;
        private const string PICKUP = "Pick Up";
        
        [Inject]
        private void Construct(UIInventory uiInventory, WorldInfoUI worldInfoUI)
        {
            _uiInventory = uiInventory;
            _worldInfoUI = worldInfoUI;
        }
        private void Awake()
        {
            inventory = new InventoryWithSlots(_inventoryCapacity);
            _uiInventory.SetInventory(inventory);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PickUpItem>(out var pickUp))
            {
                _worldInfoUI.OpenButtonActionPanel(() => PickUpItem(pickUp), PICKUP);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<PickUpItem>(out var pickUp))
            {
                _worldInfoUI.CloseButtonActionPanel();
            }
        }

        private void PickUpItem(PickUpItem pickUp)
        {
            inventory.TryToAdd(this, pickUp.item);
            Destroy(pickUp.gameObject);
        }
    }
}