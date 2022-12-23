using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Inventory.Model
{
    [CreateAssetMenu(menuName = "Objects/Drug")]
    public class DrugsSO : ConsumableItemSO
    {
        [field: SerializeField]
        public int Price { get; set; }
    }
}