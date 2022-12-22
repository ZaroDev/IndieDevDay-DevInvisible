using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Inventory.Model
{
    [CreateAssetMenu(menuName = "Objects/Plant")]
    public class PlantSO : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }
        [field: SerializeField]
        public int DaysToGrow { get; private set; }
        [field: SerializeField]
        public int DaysToHarvest { get; private set; }
        [field: SerializeField]
        public int DaysToDry { get; private set; }
        [field: SerializeField]
        public ItemSO Drop { get; private set; }
        [field: SerializeField]
        public int MinDrop { get; private set; }
        [field: SerializeField]
        public int MaxDrop { get; private set; }
        [field: SerializeField]
        public bool Permanent { get; private set; }
        [field: SerializeField]
        public GameObject Prefab { get; private set; }
    }
}