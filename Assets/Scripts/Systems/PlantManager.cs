using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : GameSystem
{
    public List<Plant> plants = new List<Plant>();

    private void OnEnable()
    {
        TimeManager.OnDayChange += GrowPlants;
    }
    private void OnDisable()
    {
        TimeManager.OnDayChange -= GrowPlants;
    }
    public void GrowPlants(int day)
    {
        foreach (Plant plant in plants)
        {
            plant.Grow();
        }
    }
}
