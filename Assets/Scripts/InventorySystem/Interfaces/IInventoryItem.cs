using System;

namespace InventorySystem.Interfaces
{
    public interface IInventoryItem
    {
        IInventoryItemInfo info { get; }
        IInventoryItemState state { get; }
        Type type { get; }
        IInventoryItem Clone();
    }
}