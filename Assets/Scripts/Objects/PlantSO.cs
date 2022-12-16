using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Objects/Plant")]
public class PlantSO : ScriptableObject
{
    public string Name;
    public int Cost;
    public int DaysToGrow;
    public int MinDrop;
    public int MaxDrop;
    public bool Permanent;
}
