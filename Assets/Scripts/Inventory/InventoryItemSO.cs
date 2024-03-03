using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown2D_Demo.Inventory
{
    [CreateAssetMenu(fileName = "InventoryItemSO", menuName = "Top Down 2D Demo", order = 0)]
    public class InventoryItemSO : ScriptableObject
    {
        [SerializeField] private string _itemName;
        [SerializeField] private int _itemPrice;
        [SerializeField] private bool _dressable;
        [SerializeField] private bool _consumable;
        [SerializeField] private GameObject _dressablePrefab;
        [SerializeField] private Sprite _itemIcon;

        public string ItemName { get => _itemName; }
        public int ItemPrice { get => _itemPrice; }
        public bool Dressable { get => _dressable; }
        public bool Consumable { get => _consumable; }
        public GameObject DressablePrefab { get => _dressablePrefab; }
        public Sprite ItemIcon { get => _itemIcon; }
    }
}
