using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    [Serializable]
    public struct ItemStats
    {
        public ItemStatsName StatsName;
        public int StatsValue;

        public ItemStats(ItemStatsName statsName, int itemValue)
        {
            StatsName = statsName;
            StatsValue = itemValue;
        }
    }
}