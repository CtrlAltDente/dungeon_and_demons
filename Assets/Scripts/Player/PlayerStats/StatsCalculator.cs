using DungeonAndDemons.Enums;
using DungeonAndDemons.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Player
{
    public abstract class StatsCalculator : MonoBehaviour
    {
        public abstract void CalculateStats(PlayerStats playerStats, PlayerCharacter playerCharacter);

        protected int GetStatsValueInItems(PlayerCharacter playerCharacter, ItemStat itemStatsName)
        {
            int statValue = 0;

            foreach (ItemSlot slot in playerCharacter.CharacterInventory.Slots)
            {
                foreach (ItemStats itemStats in slot.Item.Stats)
                {
                    if (itemStats.Stat == itemStatsName)
                    {
                        statValue += itemStats.StatValue;
                    }
                }
            }

            return statValue;
        }
    }
}