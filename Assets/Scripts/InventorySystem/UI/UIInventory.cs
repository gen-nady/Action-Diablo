﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem.UI
{
    public class UIInventory : MonoBehaviour
    {
        [SerializeField] private GameObject _panelInventory;
        [SerializeField] private UIInventorySlot _uiInventorySlotPrefab;
        [SerializeField] private RectTransform _uiInventorySlotPosition;
        [SerializeField] private GridLayoutGroup _gridLayoutGroup;
        private List<UIInventorySlot> _uiSlots = new List<UIInventorySlot>();
        public InventoryWithSlots inventory { get; private set; }

        public void SetInventory(InventoryWithSlots inventory)
        {
            this.inventory = inventory;
            inventory.OnInventoryStateChangedEvent += OnInventoryStateChanged;
        }

        public void OpenInventory()
        {
            _panelInventory.SetActive(true);
            IntantiateInventory();
            SetupInventoryUI();
        }

        public void CloseInventory()
        {
            _panelInventory.SetActive(false);
        }
        
        private void SetupInventoryUI()
        {
            var allSlots = inventory.GetAllSlots();
            for (int i = 0; i < allSlots.Count; i++)
            {
                var slot = allSlots[i];
                var uiSlot = _uiSlots[i];
                uiSlot.SetSlot(slot);
                uiSlot.Refresh();
            }
        }

        private void OnInventoryStateChanged(object sender)
        {
            if (_panelInventory.activeInHierarchy)
            { 
                foreach (var slot in _uiSlots)
                {
                    slot.Refresh();
                } 
            }
        }

        private void IntantiateInventory()
        {
            if(inventory.capacity == _uiSlots.Count) return;
            foreach (var slot in _uiSlots)
                Destroy(slot.gameObject);
            _uiSlots.Clear();
            
           
            for (int i = 0; i < inventory.capacity; i++)
            {
                var slot = Instantiate(_uiInventorySlotPrefab, _uiInventorySlotPosition);
                _uiSlots.Add(slot);
            }
            _gridLayoutGroup.enabled = true;
            Canvas.ForceUpdateCanvases();
            _gridLayoutGroup.enabled = false;
        }
    }
}