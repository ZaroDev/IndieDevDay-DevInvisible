using System.Collections;
using System.Collections.Generic;
using Inventory.Model;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    [SerializeField]
    private InventorySO invetoryData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();
        if (item != null)
        {
            int remainder = invetoryData.AddItem(item.InventoryItem, item.Quantity, item.Uses);
            if (remainder == 0)
                item.DestroyItem();
            else
                item.Quantity = remainder;
        }
    }
}
