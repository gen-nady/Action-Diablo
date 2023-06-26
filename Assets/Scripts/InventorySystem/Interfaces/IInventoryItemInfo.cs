using UnityEngine;

namespace InventorySystem.Interfaces
{
    public interface IInventoryItemInfo
    {
        string id { get; }
        string title { get; }
        string description { get; }
        int maxItemInInventorySlot { get; }
        Sprite spriteIcon { get; }
    }
}