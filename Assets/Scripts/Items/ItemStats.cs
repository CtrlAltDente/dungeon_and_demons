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
        public StatsType Type;
        public int Value;

        public ItemStats(StatsType type, int value)
        {
            Type = type;
            Value = value;
        }
    }
}