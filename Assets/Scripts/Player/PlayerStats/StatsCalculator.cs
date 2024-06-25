using DungeonAndDemons.Character;
using DungeonAndDemons.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Player
{
    public abstract class StatsCalculator : MonoBehaviour
    {
        public abstract void CalculateStats(PlayerStats playerStats, CharacterComponents characterComponents);

        protected int GetStatsValueInItems(CharacterComponents characterComponents, ItemStat itemStatsName)
        {
            int statValue = 0;

            foreach (ItemSlot slot in characterComponents.CharacterInventory.Slots)
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