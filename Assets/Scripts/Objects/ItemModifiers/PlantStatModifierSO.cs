using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlantStatModifierSO : ScriptableObject
{
    public abstract void AffectPlant(GameObject character, float val);
}
