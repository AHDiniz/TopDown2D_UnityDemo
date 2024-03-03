using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown2D_Demo.Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        private List<InventoryItem> _itemsObtained;

        public List<InventoryItem> ItemsObtained { get => _itemsObtained; }

        private void Start()
        {
            _itemsObtained = new List<InventoryItem>();
        }

        public void AddItem(InventoryItem item)
        {
            _itemsObtained.Add(item);
        }
    }
}
