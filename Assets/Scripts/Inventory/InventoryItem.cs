using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TopDown2D_Demo.Animations;

namespace TopDown2D_Demo.Inventory
{
    [System.Serializable]
    public class InventoryItem
    {
        private InventoryItemSO _inventoryItemSO;
        private GameObject _playerObject;
        private bool _bought = false;
        private bool _using = false;
        private int _amount = 0;

        public InventoryItemSO InventoryItemSO { get => _inventoryItemSO; }
        public int Amount { get => _amount; }
        public bool Using { get => _using; }
        public bool Bought { get => _bought; }
        public GameObject PlayerObject { get => _playerObject; set => _playerObject = value; }

        public InventoryItem(InventoryItemSO inventoryItemSO)
        {
            _inventoryItemSO = inventoryItemSO;
            _bought = false;
        }

        public void BuyItem()
        {
            _bought = true;
        }

        public void Equip()
        {
            _using = true;
            PlayerAnimation playerAnim = _playerObject.GetComponent<PlayerAnimation>();
            playerAnim.AddPlayerPart(_inventoryItemSO.DressablePrefab);
        }

        public void Unequip()
        {
            _using = false;
            PlayerAnimation playerAnim = _playerObject.GetComponent<PlayerAnimation>();
            playerAnim.RemovePlayerPart(_inventoryItemSO.DressablePrefab);
        }

        public void ObtainConsumable(int amount)
        {
            _amount += amount;
        }

        public void UseConsumable(int amount)
        {
            if (_amount < amount)
                _amount = 0;
            else
                _amount -= amount;
        }
    }
}
