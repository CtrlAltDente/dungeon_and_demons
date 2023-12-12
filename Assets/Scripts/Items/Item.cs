using DungeonAndDemons.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    [Serializable]
    public struct Item
    {
        public ItemType Type;
        public int ModelIndex;
        public List<ItemStats> Stats;
        public List<Modifier> Modifiers;

        public Item(ItemType type, int modelIndex, List<ItemStats> stats, List<Modifier> modifiers)
        {
            Type = type;
            ModelIndex = modelIndex;
            Stats = stats;
            Modifiers = modifiers;
        }
    }
}