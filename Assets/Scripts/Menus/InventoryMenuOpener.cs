using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TopDown2D_Demo.Inventory;

namespace TopDown2D_Demo.Menus
{
    public class InventoryMenuOpener : MonoBehaviour
    {
        [SerializeField] private MenuManager _menuManager;

        private InventoryManager _inventoryManager;

        private void Start()
        {
            _inventoryManager = GetComponent<InventoryManager>();
        }

        public void OnOpenInventory()
        {
            _menuManager.ShowInventoryItems(_inventoryManager.ItemsObtained.ToArray());
            _menuManager.ShowInventory();
        }
    }
}
