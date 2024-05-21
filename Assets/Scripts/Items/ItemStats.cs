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
        public ItemStat Stat;
        public int StatValue;

        public ItemStats(ItemStat stat, int statValue)
        {
            Stat = stat;
            StatValue = statValue;
        }
    }
}