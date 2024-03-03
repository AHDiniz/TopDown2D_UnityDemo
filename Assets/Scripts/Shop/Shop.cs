using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TopDown2D_Demo.Interactions;
using TopDown2D_Demo.Inventory;
using TopDown2D_Demo.Menus;

namespace TopDown2D_Demo.Shop
{
    public class Shop : MonoBehaviour, IInteractable
    {
        [SerializeField] private List<InventoryItemSO> _itemsToSellDefinitions = new List<InventoryItemSO>();
        [SerializeField] private MenuManager _menuManager;

        private List<InventoryItem> _itemsToSell = new List<InventoryItem>();

        void IInteractable.Interact()
        {
            _menuManager.ShowAvailableItems(_itemsToSell.ToArray());
            _menuManager.ShowShop();
        }

        private void Start()
        {
            for (int i = 0; i < _itemsToSellDefinitions.Count; ++i)
            {
                InventoryItem item = new InventoryItem(_itemsToSellDefinitions[i]);
                item.PlayerObject = GameObject.FindGameObjectWithTag("Player");
                _itemsToSell.Add(item);
            }
        }
    }
}
