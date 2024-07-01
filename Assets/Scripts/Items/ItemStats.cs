using DungeonAndDemons.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    [Serializable]
    public struct ItemStats
    {
        public ItemStatsType Type;
        public int Value;

        public ItemStats(ItemStatsType type, int value)
        {
            Type = type;
            Value = value;
        }
    }
}