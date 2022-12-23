using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu(menuName = "Objects/Inventory")]
    public class InventorySO : ScriptableObject
    {
        [SerializeField]
        private List<InventoryItem> inventoryItems;
        [SerializeField]
        private List<InventoryItem> hotBarItems;
        [field: SerializeField]
        public int Size { get; private set; } = 10;
        public event Action<Dictionary<int, InventoryItem>> OnInventoryUpdated;
        public void Initalize()
        {
            inventoryItems = new List<InventoryItem>();
            for (int i = 0; i < Size; i++)
            {
                inventoryItems.Add(InventoryItem.GetEmptyItem());
            }
        }
        public int AddItem(ItemSO item, int quantity, int uses)
        {
            if (!item.IsStackable)
            {
                while (quantity > 0 && !IsInventoryFull())
                {
                    quantity -= AddItemToFirstFreeSlot(item, 1, uses);
                }
                InformAboutChange();
                return quantity;
            }
            quantity = AddStackableItem(item, quantity, uses);
            InformAboutChange();
            return quantity;
        }

        private int AddItemToFirstFreeSlot(ItemSO item, int quantity, int uses)
        {
            InventoryItem newItem = new InventoryItem
            {
                item = item,
                quantity = quantity,
                uses = uses,
            };
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty)
                {
                    inventoryItems[i] = newItem;
                    return quantity;
                }
            }
            return 0;
        }

        private bool IsInventoryFull() => inventoryItems.Where(item => item.IsEmpty).Any() == false;

        private int AddStackableItem(ItemSO item, int quantity, int uses)
        {
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty)
                    continue;
                if (inventoryItems[i].item.ID == item.ID)
                {
                    int amountPossibleToTake =
                        inventoryItems[i].item.MaxStackSize - inventoryItems[i].quantity;
                    if (quantity > amountPossibleToTake)
                    {
                        inventoryItems[i] =
                         inventoryItems[i].ChangeQuantity(inventoryItems[i].item.MaxStackSize);
                        quantity -= amountPossibleToTake;
                    }
                    else
                    {
                        inventoryItems[i] =
                         inventoryItems[i].ChangeQuantity(inventoryItems[i].quantity + quantity);
                        InformAboutChange();
                        return 0;
                    }
                }
            }
            while (quantity > 0 && !IsInventoryFull())
            {
                int newQuantity = Mathf.Clamp(quantity, 0, item.MaxStackSize);
                quantity -= newQuantity;
                AddItemToFirstFreeSlot(item, newQuantity, uses);
            }
            return quantity;
        }

        public Dictionary<int, InventoryItem> GetCurrentInventoryState()
        {
            Dictionary<int, InventoryItem> returnValue = new Dictionary<int, InventoryItem>();
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty)
                    continue;
                returnValue[i] = inventoryItems[i];
            }
            return returnValue;
        }

        public InventoryItem GetItemAt(int itemIndex)
        {
            return inventoryItems[itemIndex];
        }

        public void AddItem(InventoryItem item)
        {
            AddItem(item.item, item.quantity, item.item.Uses);
        }

        public void SwapItems(int itemIndex1, int itemIndex2)
        {
            InventoryItem item1 = inventoryItems[itemIndex1];
            inventoryItems[itemIndex1] = inventoryItems[itemIndex2];
            inventoryItems[itemIndex2] = item1;
            InformAboutChange();
        }

        private void InformAboutChange()
        {
            OnInventoryUpdated?.Invoke(GetCurrentInventoryState());
        }

        public void RemoveItem(int itemIndex, int amount)
        {
            if (inventoryItems.Count > itemIndex)
            {
                if (inventoryItems[itemIndex].IsEmpty)
                    return;
                int reminder = inventoryItems[itemIndex].quantity - amount;
                if (reminder <= 0)
                    inventoryItems[itemIndex] = InventoryItem.GetEmptyItem();
                else
                    inventoryItems[itemIndex] = inventoryItems[itemIndex].ChangeQuantity(reminder);
                InformAboutChange();
            }
        }
        public void UseItem(int itemIndex)
        {
            InventoryItem item = inventoryItems[itemIndex];
            if (inventoryItems[itemIndex].item.IsStackable)
                RemoveItem(itemIndex, 1);
            else
                UseEquipableItem(itemIndex, 1);
        }
        public void UseEquipableItem(int itemIndex, int amount)
        {
            if (inventoryItems.Count > itemIndex)
            {
                if (inventoryItems[itemIndex].IsEmpty)
                    return;
                int reminder = inventoryItems[itemIndex].uses - amount;
                if (reminder <= 0)
                    reminder = 0;
                inventoryItems[itemIndex] = inventoryItems[itemIndex].Use(reminder);
                InformAboutChange();
            }
        }

    }

    [Serializable]
    public struct InventoryItem
    {
        public int quantity;
        public int uses;
        public ItemSO item;
        public bool IsEmpty => item == null;
        public InventoryItem Use(int usesQuantity)
        {
            return new InventoryItem
            {
                item = this.item,
                quantity = this.quantity,
                uses = usesQuantity,
            };
        }
        public InventoryItem ChangeQuantity(int newQuantity)
        {
            return new InventoryItem
            {
                item = this.item,
                quantity = newQuantity,
                uses = this.uses,
            };
        }
        public static InventoryItem GetEmptyItem()
         => new InventoryItem
         {
             item = null,
             quantity = 0,
             uses = 0,
         };


    }
}