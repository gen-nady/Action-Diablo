using System;
using System.Collections.Generic;

namespace InventorySystem.Interfaces
{
    public interface IInventory
    {
        int capacity { get; set; }
        bool isFull { get; }
        IInventoryItem GetItem(Type itemType);
        List<IInventoryItem> GetAllItems();
        List<IInventoryItem> GetAllItems(Type itemType);
        List<IInventoryItem> GetEquippedItems();
        int GetItemAmount(Type itemType);

        bool TryToAdd(object sender, IInventoryItem item);
        void Remove(object sender, Type itemType, int amount = 1);
        bool HasItem(Type type, out IInventoryItem item);
    }
}