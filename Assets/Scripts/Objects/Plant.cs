using System;
using System.Collections;
using System.Collections.Generic;
using Inventory.Model;
using UnityEngine;
using Random = UnityEngine.Random;

public enum PlantState
{
    Seed = 0,
    Mid,
    Grown,
    Harvestable,
    Dry
}

public class Plant : MonoBehaviour
{
    [field: SerializeField]
    public PlantSO PlantData { get; set; }
    [field: SerializeField]
    private SpriteRenderer Sprite;
    [field: SerializeField]
    private PlantState State;
    public int DaysToGrow { get; private set; }
    public int DaysToDry { get; private set; }
    public int DaysToHarvest { get; private set; }
    public bool Watered { get; set; } = false;
    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
        DaysToDry = PlantData.DaysToDry;
        DaysToGrow = PlantData.DaysToGrow;
        DaysToHarvest = PlantData.DaysToHarvest;
        UpdateAnim();
    }
    public void Grow()
    {
        if (!Watered)
        {
            DaysToDry--;
            if (DaysToDry < 0)
                Destroy(gameObject);

            State = PlantState.Dry;
            UpdateAnim();
            return;
        }
        DaysToHarvest--;
        DaysToGrow--;

        int grownPercent = DaysToGrow / PlantData.DaysToGrow;
        if (DaysToGrow == 1)
            State = PlantState.Seed;
        else if (DaysToGrow == 0.5f)
            State = PlantState.Mid;

        if (DaysToGrow <= 0)
            State = PlantState.Grown;
        if (DaysToHarvest <= 0)
            State = PlantState.Harvestable;

        UpdateAnim();

        Watered = false;
    }
    public void Harvest()
    {
        if (State != PlantState.Harvestable)
            return;
        int dropCount = Random.Range(PlantData.MinDrop, PlantData.MaxDrop + 1);

        for (int i = 0; i < dropCount; i++)
        {
            var go = Instantiate(PlantData.Drop.prefab, transform.position, Quaternion.identity);
            Item item = go.GetComponent<Item>();
            item.Quantity = 1;
            item.InventoryItem = PlantData.Drop;
        }
        State = PlantState.Grown;
        UpdateAnim();
    }
    void UpdateAnim()
    {

        switch (State)
        {
            case PlantState.Seed:
                {
                    Sprite.sprite = PlantData.SeedSprite;
                }
                break;
            case PlantState.Mid:
                {
                    Sprite.sprite = PlantData.MidSprite;
                }
                break;
            case PlantState.Grown:
                {
                    Sprite.sprite = PlantData.GrownSprite;
                }
                break;
            case PlantState.Harvestable:
                {
                    Sprite.sprite = PlantData.HarvestableSprite;
                }
                break;
            case PlantState.Dry:
                {
                    Sprite.sprite = PlantData.DrySprite;
                }
                break;
        }

    }
}
