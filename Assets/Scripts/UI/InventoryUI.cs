using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Inventory.UI
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField]
        private InventoryItemUI itemPrefab;
        [SerializeField]
        private RectTransform contentPanel;
        [SerializeField]
        private RectTransform hotbarPanel;

        [SerializeField]
        private InventoryDescriptionUI itemDescription;
        [SerializeField]
        private MouseFollower mouseFollower;
        public List<InventoryItemUI> UIItems = new List<InventoryItemUI>();
        private int currentlyDraggedIndex = -1;

        public event Action<int> OnDescriptionRequested, OnItemActionRequested, OnStartDragging;
        public event Action<int, int> OnSwapItems;

        void Awake()
        {
            Hide();
            itemDescription.ResetDescription();
            mouseFollower.Toggle(false);
        }
        public void IntializeInventoriUI(int inventorySize)
        {
            for (int i = 0; i < inventorySize; i++)
            {
                InventoryItemUI uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
                if (i < 4)
                    uiItem.transform.SetParent(hotbarPanel);
                else
                    uiItem.transform.SetParent(contentPanel);
                uiItem.transform.localScale = new Vector3(1f, 1f, 1f);
                UIItems.Add(uiItem);
                uiItem.OnItemClicked += HandleItemSelection;
                uiItem.OnItemBeginDrag += HandleBeginDrag;
                uiItem.OnItemDroppedOn += HandleSwap;
                uiItem.OnItemEndDrag += HandleEndDrag;
                uiItem.OnRightMouseBtnClick += HandleShowItemAction;
            }

        }
        public void UpdateData(int itemIndex, Sprite itemImage, int itemQuantity, int itemUses)
        {
            if (UIItems.Count > itemIndex)
            {
                UIItems[itemIndex].SetData(itemImage, itemQuantity, itemUses);
            }
        }
        private void HandleShowItemAction(InventoryItemUI inventoryItemUI)
        {
            int index = UIItems.IndexOf(inventoryItemUI);
            if (index == -1)
            {
                return;
            }
            OnItemActionRequested?.Invoke(index);
        }
        private void HandleEndDrag(InventoryItemUI inventoryItemUI)
        {
            ResetDraggedItem();
        }

        private void HandleSwap(InventoryItemUI inventoryItemUI)
        {
            int index = UIItems.IndexOf(inventoryItemUI);
            if (index == -1)
            {
                return;
            }
            OnSwapItems?.Invoke(currentlyDraggedIndex, index);
            HandleItemSelection(inventoryItemUI);
        }

        private void ResetDraggedItem()
        {
            mouseFollower.Toggle(false);
            currentlyDraggedIndex = -1;
        }

        private void HandleBeginDrag(InventoryItemUI inventoryItemUI)
        {
            int index = UIItems.IndexOf(inventoryItemUI);
            if (index == -1)
                return;
            currentlyDraggedIndex = index;
            HandleItemSelection(inventoryItemUI);
            OnStartDragging?.Invoke(index);
        }
        public void CreateDraggedItem(Sprite sprite, int quantity, int itemUses)
        {
            mouseFollower.Toggle(true);
            mouseFollower.SetData(sprite, quantity, itemUses);
        }
        private void HandleItemSelection(InventoryItemUI inventoryItemUI)
        {
            int index = UIItems.IndexOf(inventoryItemUI);
            if (index == -1)
                return;
            OnDescriptionRequested?.Invoke(index);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            itemDescription.ResetDescription();
            ResetSelection();
        }
        public void ResetSelection()
        {
            itemDescription.ResetDescription();
            DeselectAllItems();
        }
        public void ResetHotbar()
        {
            for (int i = 0; i < 4; i++)
            {
                UIItems[i].Deselect();
            }
        }
        public void DeselectAllItems()
        {
            foreach (InventoryItemUI item in UIItems)
            {
                item.Deselect();
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            ResetDraggedItem();
        }

        internal void UpdateDescription(int itemIndex, Sprite itemImage, string name, string description)
        {
            itemDescription.SetDescription(itemImage, name, description);
            DeselectAllItems();
            UIItems[itemIndex].Select();
        }

        internal void ResetAllItems()
        {
            foreach (var item in UIItems)
            {
                item.ResetData();
                item.Deselect();
            }
        }
    }
}