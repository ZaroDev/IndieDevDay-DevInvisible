using System.Collections;
using System.Collections.Generic;
using Inventory;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Camera Cam;
    public LayerMask Interactable;
    public InventoryController inventory;
    void Awake()
    {
        Cam = Camera.main;
        inventory = GetComponent<InventoryController>();
    }
    void Update()
    {
        CheckInteraction();
    }
    void CheckInteraction()
    {
        if (Input.GetMouseButton(0))
        {
            var point = Cam.ScreenPointToRay(Input.mousePosition).GetPoint(1);
            Ray2D ray = new Ray2D(gameObject.transform.position, point);
            Debug.DrawRay(ray.origin, ray.direction, Color.green);

            RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, point, 2f, Interactable);
            if (hit.collider)
            {
                Debug.Log($"Interaction with {hit.collider.gameObject.name}");
                IInteractable interactable = hit.collider.gameObject.GetComponent<IInteractable>();
                if (interactable.Interact(inventory.currentItem))
                {

                }
            }
        }
    }
}
