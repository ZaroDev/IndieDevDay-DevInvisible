using System.Collections;
using System.Collections.Generic;
using Inventory.Model;
using UnityEngine;

public class Plot : MonoBehaviour, IInteractable
{
    public bool Watered = false;
    public Animator PlotAnimator;
    public Plant plant;

    void OnEnable()
    {
        TimeManager.OnPlantGrow += OnDayChange;
    }
    void OnDisable()
    {
        TimeManager.OnPlantGrow -= OnDayChange;
    }
    void Start()
    {
        PlotAnimator = GetComponent<Animator>();
    }
    public void OnDayChange()
    {
        if (plant == null)
            return;


        plant.Watered = Watered;
        plant.Grow();
        if (Watered)
        {
            Watered = false;
        }
        PlotAnimator.SetBool("Watered", Watered);
    }

    public bool Interact(InventoryItem inventoryItem)
    {
        bool ret = true;
        ItemSO item = inventoryItem.item;
        switch (item.ItemType)
        {
            case ItemType.None: break;
            case ItemType.Seed:
                {
                    if (plant != null)
                    {
                        ret = false;
                        break;
                    }

                    SeedItemSO seed = item as SeedItemSO;
                    var go = Instantiate(seed.Plant.Prefab, transform.position, Quaternion.identity, transform);
                    plant = go.GetComponent<Plant>();
                    plant.PlantData = seed.Plant;

                }
                break;
            case ItemType.WateringCan:
                {
                    Watered = true;
                }
                break;
            case ItemType.Sickle:
                {
                    if (!plant.Harvest())
                    {
                        plant = null;
                    }

                }
                break;
        }
        PlotAnimator.SetBool("Watered", Watered);
        return ret;
    }
}
