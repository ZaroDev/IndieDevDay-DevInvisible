using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlantStatus
{
    Seed = 0,
    MidGrow,
    Grown,
    Dry
}
public class Plant : MonoBehaviour
{
    public PlantSO PlantRef;
    public int Days = 0;
    public int DaysUnWatered = 0;
    public PlantStatus Status = 0;
    public bool Watered = false;
    void Start()
    {

    }
    public void Harvest()
    {
        if (PlantRef.Permanent)
        {
            Days = 0;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Grow()
    {
        if (!Watered)
        {
            DaysUnWatered++;
            Status = PlantStatus.Dry;
            if (DaysUnWatered >= PlantRef.DaysToDry)
            {
                Destroy(gameObject);
            }
            return;
        }


        Days++;
        float statusPerCent = Days / PlantRef.DaysToGrow;
        if (statusPerCent >= 0f && statusPerCent < 0.3f)
        {
            Status = PlantStatus.Seed;
        }
        else if (statusPerCent >= 0.3f && statusPerCent < 1f)
        {
            Status = PlantStatus.MidGrow;
        }
        else if (statusPerCent >= 1f)
        {
            Status = PlantStatus.Grown;
        }
    }
}
