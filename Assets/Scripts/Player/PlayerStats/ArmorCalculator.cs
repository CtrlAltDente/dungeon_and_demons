using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Player
{
    public class ArmorCalculator : StatsCalculator
    {
        public override void CalculateStats(PlayerStats playerStats, PlayerCharacter playerCharacter)
        {
            int armorDamageStats = GetStatsValueInItems(playerCharacter, ItemStatsName.Armor);
            playerStats.ArmorValue = armorDamageStats;
        }
    }
}
