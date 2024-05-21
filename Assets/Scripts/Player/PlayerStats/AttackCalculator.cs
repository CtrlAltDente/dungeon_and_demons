using DungeonAndDemons.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Player
{
    public class AttackCalculator : StatsCalculator
    {
        public override void CalculateStats(PlayerStats playerStats, PlayerCharacter playerCharacter)
        {
            int attackDamageStats = GetStatsValueInItems(playerCharacter, ItemStat.Attack);
            playerStats.AttackDamage = attackDamageStats + playerCharacter.CharacterAttributes.Strength * 2;
        }
    }
}