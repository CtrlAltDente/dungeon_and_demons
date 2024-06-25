using DungeonAndDemons.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Player
{
    public class ArmorCalculator : StatsCalculator
    {
        public override void CalculateStats(PlayerStats playerStats, CharacterComponents characterComponents)
        {
            int armorDamageStats = GetStatsValueInItems(characterComponents, ItemStat.Armor);
            playerStats.ArmorValue = armorDamageStats;
        }
    }
}
