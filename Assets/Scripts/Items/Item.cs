using DungeonAndDemons.Enums;
using DungeonAndDemons.ModifiersLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    [Serializable]
    public struct Item
    {
        public SlotType SlotType;
        public int ModelIndex;
        public List<ItemStats> Stats;
        public List<Modifier> Modifiers;

        public Item(SlotType type, int modelIndex, List<ItemStats> stats, List<Modifier> modifiers)
        {
            SlotType = type;
            ModelIndex = modelIndex;
            Stats = stats;
            Modifiers = modifiers;
        }
    }
}