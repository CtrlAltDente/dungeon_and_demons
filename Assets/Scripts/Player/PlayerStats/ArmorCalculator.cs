using DungeonAndDemons.Character;
using DungeonAndDemons.Enums;
using UnityEngine;

namespace DungeonAndDemons.Player
{
    public class ArmorCalculator : StatsCalculator
    {
        public override void CalculateStats(PlayerStats playerStats, CharacterComponents characterComponents)
        {
            int armorDamageStats = GetStatsValueInItems(characterComponents, ItemStatsType.Armor);
            playerStats.ArmorValue = armorDamageStats;
        }
    }
}
