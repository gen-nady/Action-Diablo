using System;
using InventorySystem.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InventorySystem.UI
{
    public class UIInventorySlot : UISlot
    {
        [SerializeField] private UIInventoryItem _uiInventoryItem;
        public IInventorySlot slot { get; private set; }
        private UIInventory _uiInventory;

        private void OnEnable()
        {
            _uiInventory = GetComponentInParent<UIInventory>();
        }

        public void SetSlot(IInventorySlot newSlot)
        {
            slot = newSlot;
        }
        
        public override void OnDrop(PointerEventData eventData)
        {
            var otherItemUI = eventData.pointerDrag.GetComponent<UIInventoryItem>();
            var otherSlotUI = otherItemUI.GetComponentInParent<UIInventorySlot>();
            var otherSlot = otherSlotUI.slot;
            var inventory = _uiInventory.inventory;
            
            inventory.TransitFromSlotToSlot(this, otherSlot, slot);
            Refresh();
            otherSlotUI.Refresh();
        }

        public void Refresh()
        {
            if (slot != null)
            {
                _uiInventoryItem.Refresh(slot);
            }
        }
    }
}