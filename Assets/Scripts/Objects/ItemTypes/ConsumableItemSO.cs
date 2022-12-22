using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu(menuName = "Objects/Consumbale")]
    public class ConsumableItemSO : ItemSO, IDestroyableItem, IItemAction
    {
        [SerializeField]
        private List<ModifierData> modifierData = new List<ModifierData>();
        public string ActionName => "Consume";

        public AudioClip ActionSFX { get; private set; }

        public bool PerformAction(GameObject plant)
        {
            foreach (ModifierData data in modifierData)
            {
                data.statModifier.AffectPlant(plant, data.value);
            }
            return true;
        }
    }
    public interface IDestroyableItem
    {

    }
    public interface IItemAction
    {
        public string ActionName { get; }
        public AudioClip ActionSFX { get; }
        bool PerformAction(GameObject plant);
    }
    [Serializable]
    public class ModifierData
    {
        public PlantStatModifierSO statModifier;
        public float value;
    }
}
