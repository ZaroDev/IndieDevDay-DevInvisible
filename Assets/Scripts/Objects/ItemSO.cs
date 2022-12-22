using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    public enum ItemType
    {
        None,
        Seed,
        WateringCan
    }
    public abstract class ItemSO : ScriptableObject
    {
        [field: SerializeField]
        public ItemType ItemType { get; set; } = ItemType.None;
        [field: SerializeField]
        public bool IsStackable { get; set; }
        public int ID => GetInstanceID();
        [field: SerializeField]
        public int MaxStackSize { get; set; } = 1;
        [field: SerializeField]
        public string Name { get; set; }
        [field: SerializeField]
        [field: TextArea]
        public string Description { get; set; }
        [field: SerializeField]
        public Sprite ItemImage { get; set; }
        [field: SerializeField]
        public GameObject prefab { get; private set; }
    }
}