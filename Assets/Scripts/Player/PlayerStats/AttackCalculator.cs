using DungeonAndDemons.Character;
using DungeonAndDemons.Enums;
using UnityEngine;

namespace DungeonAndDemons.Player
{
    public class AttackCalculator : StatsCalculator
    {
        public override void CalculateStats(PlayerStats playerStats, CharacterComponents characterComponents)
        {
            int attackDamageStats = GetStatsValueInItems(characterComponents, StatsType.Attack);
            playerStats.AttackDamage = attackDamageStats + characterComponents.CharacterAttributes.Strength * 2;
        }
    }
}