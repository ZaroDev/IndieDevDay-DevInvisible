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
    public PlantSO PlantData { get; private set; }
    [field: SerializeField]
    private Animator Animator;
    [field: SerializeField]
    private PlantState State;
    public int DaysToGrow { get; private set; }
    public int DaysToDry { get; private set; }
    public int DaysToHarvest { get; private set; }
    public bool Watered { get; set; } = false;
    void Start()
    {
        Animator = GetComponent<Animator>();
        DaysToDry = PlantData.DaysToDry;
        DaysToGrow = PlantData.DaysToGrow;
        DaysToHarvest = PlantData.DaysToHarvest;
    }
    public void Grow()
    {
        if (!Watered)
        {
            DaysToDry--;
            if (DaysToDry < 0)
                Destroy(gameObject);

            State = PlantState.Dry;
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
            Instantiate(PlantData.Drop, transform.position, Quaternion.identity, transform);
        }
        State = PlantState.Grown;
        UpdateAnim();
    }
    void UpdateAnim()
    {
        string animName = "";
        switch (State)
        {
            case PlantState.Seed:
                animName = "PlantSeed";
                break;
            case PlantState.Mid:
                animName = "PlantMid";
                break;
            case PlantState.Grown:
                animName = "PlantGrown";
                break;
            case PlantState.Harvestable:
                animName = "PlantHarvestable";
                break;
            case PlantState.Dry:
                animName = "PlantDry";
                break;
        }
        Animator.Play(animName);
    }
}
