using System.Collections;
using System.Collections.Generic;
using Inventory;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Camera Cam;
    public LayerMask Interactable;
    public InventoryController Inventory;
    public float InteractionDistance = 1f;
    void Awake()
    {
        Cam = Camera.main;
        Inventory = GetComponent<InventoryController>();
    }
    void Update()
    {
        CheckInteraction();
    }
    void CheckInteraction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, InteractionDistance, Interactable);
            if (hit.collider)
            {
                if (Vector2.Distance(transform.position, hit.collider.gameObject.transform.position) > InteractionDistance)
                    return;
                if (Inventory.currentItem.quantity <= 0)
                    return;
                IInteractable interactable = hit.collider.gameObject.GetComponent<IInteractable>();
                if (interactable.Interact(Inventory.currentItem))
                {
                    StaminaController.Use(10f);
                    Inventory.inventoryData.UseItem(Inventory.currentIndex);
                }
            }
        }
    }
}
