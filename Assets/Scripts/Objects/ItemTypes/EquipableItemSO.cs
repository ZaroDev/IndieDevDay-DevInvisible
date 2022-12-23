using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Inventory.Model
{
    [CreateAssetMenu(menuName = "Objects/Equip")]
    public class EquipableItemSO : ItemSO, IItemAction
    {
        public string ActionName => "Use";
        [field: SerializeField]
        public AudioClip ActionSFX { get; private set; }

        public bool PerformAction(GameObject plant)
        {
            return true;
        }
    }
}
