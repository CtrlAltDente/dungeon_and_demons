using DungeonAndDemons.Character;
using DungeonAndDemons.Enums;
using UnityEngine;

namespace DungeonAndDemons.Player
{
    public class ArmorCalculator : StatsCalculator
    {
        public override void CalculateStats(PlayerStats playerStats, CharacterComponents characterComponents)
        {
            int armorDamageStats = GetStatsValueInItems(characterComponents, StatsType.Armor);
            playerStats.ArmorValue = armorDamageStats;
        }
    }
}
