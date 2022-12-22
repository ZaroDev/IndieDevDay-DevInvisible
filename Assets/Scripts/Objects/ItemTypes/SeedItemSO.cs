using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu(menuName = "Objects/Seed")]
    public class SeedItemSO : ConsumableItemSO
    {
        [field: SerializeField]
        public PlantSO Plant { get; private set; }
        
    }
}