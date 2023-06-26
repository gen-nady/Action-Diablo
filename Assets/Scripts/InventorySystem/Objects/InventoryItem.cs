using System;
using InventorySystem.Interfaces;
using InventorySystem.Objects;

namespace InventorySystem
{
    public class InventoryItem : IInventoryItem
    {
        public IInventoryItemInfo info { get; }
        public IInventoryItemState state { get; }
        public Type type => GetType();

        public InventoryItem(IInventoryItemInfo info)
        {
            this.info = info;
            state = new InventoryItemState();
        }

        public IInventoryItem Clone()
        {
            var clonned = new InventoryItem(info);
            clonned.state.amount = state.amount;
            return clonned;
        }
    }
}