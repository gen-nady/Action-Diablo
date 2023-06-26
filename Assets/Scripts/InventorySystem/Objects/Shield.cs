using System;
using InventorySystem.Interfaces;
using InventorySystem.Objects;

namespace InventorySystem
{
    public class Shield : InventoryItem
    {
        public Shield(IInventoryItemInfo info) : base(info)
        {
        }
    }
}