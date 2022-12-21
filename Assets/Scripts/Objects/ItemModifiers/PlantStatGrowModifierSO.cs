using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantStatGrowModifierSO : PlantStatModifierSO
{
    public override void AffectPlant(GameObject plant, float val)
    {
        Plant plantCmp = plant.GetComponent<Plant>();
        if (plantCmp != null)
        {

        }
    }
}
