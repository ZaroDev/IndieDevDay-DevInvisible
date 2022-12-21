using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu(menuName = "Objects/Seed")]
    public class SeedItemSO : EdibleItemSO
    {
        [field: SerializeField]
        public PlantSO Plant { get; private set; }
    }
}