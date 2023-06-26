using System;
using InventorySystem.Interfaces;
using InventorySystem.Objects;
using UnityEngine;

namespace InventorySystem
{
    public class Sword : InventoryItem
    {
        public Sword(IInventoryItemInfo info) : base(info)
        {
        }
    }
}