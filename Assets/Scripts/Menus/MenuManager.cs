using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TopDown2D_Demo.Inventory;

namespace TopDown2D_Demo.Menus
{
    [RequireComponent(typeof(UIDocument))]
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private VisualTreeAsset _storeItemAsset;
        [SerializeField] private VisualTreeAsset _inventoryItemAsset;
        [SerializeField] private InventoryManager _inventory;

        private UIDocument _uiDocument;
        private VisualElement _shopPage;
        private VisualElement _inventoryPage;

        private void Start()
        {
            _uiDocument = GetComponent<UIDocument>();

            _shopPage = _uiDocument.rootVisualElement.Q<VisualElement>("Shop");
            _shopPage.Q<Button>("CloseShop").RegisterCallback<PointerUpEvent>((e) => HideShop());
            
            _inventoryPage = _uiDocument.rootVisualElement.Q<VisualElement>("Inventory");
            _inventoryPage.Q<Button>("CloseInventory").RegisterCallback<PointerUpEvent>((e) => HideInventory());
        }

        public void ShowShop()
        {
            _shopPage.style.display = DisplayStyle.Flex;
        }

        public void HideShop()
        {
            _shopPage.style.display = DisplayStyle.None;
            _shopPage.Q<ScrollView>("ItemScrolling").Clear();
        }

        public void ShowInventory()
        {
            _inventoryPage.style.display = DisplayStyle.Flex;
        }

        public void HideInventory()
        {
            _inventoryPage.style.display = DisplayStyle.None;
            _inventoryPage.Q<ScrollView>("ItemScrolling").Clear();
        }

        public void ShowAvailableItems(InventoryItem[] items)
        {
            foreach (InventoryItem item in items)
            {
                if (!item.Bought && item.InventoryItemSO.Dressable)
                {
                    VisualElement itemElement = _storeItemAsset.Instantiate();
                    itemElement.Q<VisualElement>("ItemIcon").style.backgroundImage = new StyleBackground(item.InventoryItemSO.ItemIcon);
                    itemElement.Q<Label>("ItemName").text = item.InventoryItemSO.ItemName + " (" + item.InventoryItemSO.ItemPrice + ")";
                    itemElement.Q<Button>("BuyItem").RegisterCallback<PointerUpEvent>((e) => {
                        item.BuyItem();
                        _inventory.AddItem(item);
                    });
                    _shopPage.Q<ScrollView>("ItemScrolling").Add(itemElement);
                }
            }
        }

        public void ShowInventoryItems(InventoryItem[] items)
        {
            foreach (InventoryItem item in items)
            {
                if (item.InventoryItemSO == null) return;
                if (item.Bought || (item.InventoryItemSO.Consumable && item.Amount > 0))
                {
                    VisualElement itemElement = _inventoryItemAsset.Instantiate();
                    itemElement.Q<VisualElement>("ItemIcon").style.backgroundImage = new StyleBackground(item.InventoryItemSO.ItemIcon);
                    string name = item.InventoryItemSO.ItemName;
                    itemElement.Q<Label>("ItemName").text = item.InventoryItemSO.Consumable ? name + " (" + item.Amount + ")" : name;
                    Button button = itemElement.Q<Button>("ItemUsage");
                    if (item.Using)
                    {
                        button.text = "Unequip";
                        button.RegisterCallback<PointerUpEvent>((e) => {
                            item.Unequip();
                        });
                    }
                    else
                    {
                        button.text = "Equip";
                        button.RegisterCallback<PointerUpEvent>((e) => {
                            item.Equip();
                        });
                    }
                    _inventoryPage.Q<ScrollView>("ItemScrolling").Add(itemElement);
                }
            }
        }
    }
}
