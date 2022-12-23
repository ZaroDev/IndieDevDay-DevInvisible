using System;
using System.Collections;
using System.Collections.Generic;
using Inventory.Model;
using Inventory.UI;
using UnityEngine;

namespace Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField]
        private InventoryUI inventoryUI;
        [SerializeField]
        public InventorySO inventoryData;
        public List<InventoryItem> initialItems = new List<InventoryItem>();
        public InventoryItem currentItem;
        public int currentIndex = 0;
        public void Start()
        {
            PrepareUI();
            PrepareInventoryData();
            currentItem = inventoryData.GetItemAt(currentIndex);
        }

        private void CheckInput()
        {
            if (Input.mouseScrollDelta.y < -0.1f)
            {
                currentIndex++;
                if (currentIndex > 3)
                {
                    currentIndex = 0;
                }
                currentItem = inventoryData.GetItemAt(currentIndex);
                inventoryUI.ResetHotbar();
            }
            else if (Input.mouseScrollDelta.y > 0.1f)
            {
                currentIndex--;
                if (currentIndex < 0)
                {
                    currentIndex = 3;
                }
                currentItem = inventoryData.GetItemAt(currentIndex);
                inventoryUI.ResetHotbar();
            }
            inventoryUI.UIItems[currentIndex].Select();
        }

        private void PrepareInventoryData()
        {
            inventoryData.Initalize();
            inventoryData.OnInventoryUpdated += UpdateInventoryUI;
            foreach (InventoryItem item in initialItems)
            {
                if (item.IsEmpty)
                    continue;
                inventoryData.AddItem(item);
            }
        }

        private void UpdateInventoryUI(Dictionary<int, InventoryItem> inventoryState)
        {
            inventoryUI.ResetAllItems();
            foreach (var item in inventoryState)
            {

                inventoryUI.UpdateData(
                    item.Key,
                    item.Value.item.ItemImage,
                    item.Value.quantity,
                    item.Value.uses
                );
            }
        }

        private void PrepareUI()
        {
            inventoryUI.IntializeInventoriUI(inventoryData.Size);
            inventoryUI.OnDescriptionRequested += HandleDescriptionRequest;
            inventoryUI.OnSwapItems += HandleSwapItems;
            inventoryUI.OnStartDragging += HandleDragging;
            inventoryUI.OnItemActionRequested += HandleItemActionRequest;
        }

        private void HandleItemActionRequest(int itemIndex)
        {
            InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty)
                return;
            IItemAction itemAction = inventoryItem.item as IItemAction;
            if (itemAction != null)
            {
                itemAction.PerformAction(gameObject);
            }
            IDestroyableItem destroyableItem = inventoryItem.item as IDestroyableItem;
            if (destroyableItem != null)
            {
                inventoryData.RemoveItem(itemIndex, 1);
            }
        }

        private void HandleDragging(int itemIndex)
        {
            InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty)
                return;
            inventoryUI.CreateDraggedItem(inventoryItem.item.ItemImage, inventoryItem.quantity, inventoryItem.uses);
        }

        private void HandleSwapItems(int itemIndex1, int itemIndex2)
        {
            inventoryData.SwapItems(itemIndex1, itemIndex2);
        }

        private void HandleDescriptionRequest(int itemIndex)
        {
            InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty)
            {
                inventoryUI.ResetSelection();
                return;
            }
            ItemSO item = inventoryItem.item;
            inventoryUI.UpdateDescription(itemIndex, item.ItemImage, item.name, item.Description);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (!inventoryUI.isActiveAndEnabled)
                {
                    inventoryUI.Show();
                    foreach (var item in inventoryData.GetCurrentInventoryState())
                    {
                        inventoryUI.UpdateData(
                            item.Key,
                            item.Value.item.ItemImage,
                            item.Value.quantity,
                            item.Value.uses
                        );

                    }
                }
                else
                {
                    inventoryUI.Hide();
                }
            }
            CheckInput();
        }
    }

}