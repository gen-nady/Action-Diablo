using System;
using System.Collections.Generic;
using System.Linq;

namespace InventorySystem
{
    public class InventoryWithSlots
    {
        public event Action<object, InventoryItem, int> OnInventoryItemAddedEvent;
        public event Action<object, Type, int> OnInventoryItemRemovedEvent;
        public event Action<object> OnInventoryStateChangedEvent;
        public int capacity { get; set; }
        public bool isFull => _slots.All(_ => _.isFull);

        private List<InventorySlot> _slots;

        public InventoryWithSlots(int capacity)
        {
            this.capacity = capacity;
            _slots = new List<InventorySlot>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                _slots.Add(new InventorySlot());
            }
        }
        
        public InventoryItem GetItem(Type itemType)
        {
            return _slots.Find(_ => _.itemType == itemType).item;
        }

        public List<InventoryItem> GetAllItems()
        {
            return _slots.Where(_ => !_.isEmpty)
                         .Select(_ => _.item)
                         .ToList();
        }

        public List<InventoryItem> GetAllItems(Type itemType)
        {
            return _slots.Where(_ => !_.isEmpty && _.itemType == itemType)
                         .Select(_ => _.item)
                         .ToList();
        }

        public List<InventoryItem> GetEquippedItems()
        {
            return _slots.Where(_ => !_.isEmpty && _.item.state.isEquipped)
                .Select(_ => _.item)
                .ToList();
        }

        public int GetItemAmount(Type itemType)
        {
            return _slots.Where(_ => !_.isEmpty && _.itemType == itemType)
                .Select(_ => _.item)
                .Sum(_ => _.state.amount);
        }

        public bool TryToAdd(object sender, InventoryItem item)
        {
            var slotWithSameItemButNotEmpty = _slots.Find(_ => !_.isEmpty && _.itemType == item.type && !_.isFull);
            if (slotWithSameItemButNotEmpty != null)
                return TryAddToSlot(sender, slotWithSameItemButNotEmpty, item);
            
            var emptySlot = _slots.Find(_ => _.isEmpty);
            if (emptySlot != null)
                return TryAddToSlot(sender, emptySlot, item);
            
            return false;
        }

        private bool TryAddToSlot(object sender, InventorySlot slot, InventoryItem item)
        {
            var fits = slot.amount + item.state.amount <= item.info.maxItemInInventorySlot;
            var amountToAdd = fits ? item.state.amount : item.info.maxItemInInventorySlot - slot.amount;
            var amountLeft = item.state.amount - amountToAdd;
            var clonedItem = item.Clone();
            clonedItem.state.amount = amountToAdd;
            
            if(slot.isEmpty)
                slot.SetItem(clonedItem);
            else
                slot.item.state.amount += amountToAdd;
            
            OnInventoryStateChangedEvent?.Invoke(sender);
            OnInventoryItemAddedEvent?.Invoke(sender, item, amountToAdd);
            
            if (amountLeft <= 0) return true;

            item.state.amount = amountLeft;
            return TryToAdd(sender, item);
        }

        public void TransitFromSlotToSlot(object sender, InventorySlot fromSlot, InventorySlot toSlot)
        {
            if(fromSlot == toSlot) return;
            
            if(fromSlot.isEmpty) return;
            
            if(toSlot.isFull) return;
            
            if(!toSlot.isEmpty && fromSlot. itemType != toSlot.itemType) return;

            var slotcapacity = fromSlot.capacity;
            var fits = fromSlot.amount + toSlot.amount <= slotcapacity;
            var amountToAdd = fits ? fromSlot.amount : slotcapacity - toSlot.amount;
            var amountLeft = fromSlot.amount - amountToAdd;

            if (toSlot.isEmpty)
            {
                toSlot.SetItem(fromSlot.item);
                fromSlot.Clear();
                OnInventoryStateChangedEvent?.Invoke(sender);
            }

            toSlot.item.state.amount += amountToAdd;
            if (fits)
                fromSlot.Clear();
            else
                fromSlot.item.state.amount = amountLeft;
            OnInventoryStateChangedEvent?.Invoke(sender);
        }
        
        public void Remove(object sender, Type itemType, int amount = 1)
        {
            var slotsWithItem = GetAllSlots(itemType);
            if(slotsWithItem.Count == 0) return;

            var amountToRemove = amount;
            var count = slotsWithItem.Count;

            for (int i = count - 1; i >= 0; i--)
            {
                var slot = slotsWithItem[i];
                if (slot.amount >= amountToRemove)
                {
                    slot.item.state.amount -= amountToRemove;
                    if (slot.amount <= 0)
                        slot.Clear();
                    OnInventoryStateChangedEvent?.Invoke(sender);
                    OnInventoryItemRemovedEvent?.Invoke(sender, itemType, amountToRemove);
                    break;
                }

                var amountRemoved = slot.amount;
                amountToRemove -= slot.amount;
                slot.Clear();
                OnInventoryStateChangedEvent?.Invoke(sender);
                OnInventoryItemRemovedEvent?.Invoke(sender, itemType, amountRemoved);
            }
        }

        public List<InventorySlot> GetAllSlots(Type itemType)
        {
            return _slots.FindAll(_ => !_.isEmpty && _.itemType == itemType);
        }
        
        public List<InventorySlot> GetAllSlots()
        {
            return _slots;
        }

        public bool HasItem(Type type, out InventoryItem item)
        {
            item = GetItem(type);
            return item != null;
        }
    }
}