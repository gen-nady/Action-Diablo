using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "Item", menuName = "Items/Item")]
    public class Item : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private string _itemName;
        [SerializeField] private Sprite _icon;
        
    }
}