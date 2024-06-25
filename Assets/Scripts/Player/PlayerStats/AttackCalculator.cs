using DungeonAndDemons.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Player
{
    public class AttackCalculator : StatsCalculator
    {
        public override void CalculateStats(PlayerStats playerStats, CharacterComponents characterComponents)
        {
            int attackDamageStats = GetStatsValueInItems(characterComponents, ItemStat.Attack);
            playerStats.AttackDamage = attackDamageStats + characterComponents.CharacterAttributes.Strength * 2;
        }
    }
}