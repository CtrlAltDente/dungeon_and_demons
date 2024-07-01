using DungeonAndDemons.Character;
using DungeonAndDemons.Enums;
using DungeonAndDemons.Items;
using UnityEngine;

namespace DungeonAndDemons.Player
{
    public abstract class StatsCalculator : MonoBehaviour
    {
        public abstract void CalculateStats(PlayerStats playerStats, CharacterComponents characterComponents);

        protected int GetStatsValueInItems(CharacterComponents characterComponents, StatsType itemStatsType)
        {
            int statValue = 0;

            foreach (ItemSlot slot in characterComponents.CharacterInventory.Slots)
            {
                foreach (ItemStats itemStats in slot.Item.Stats)
                {
                    if (itemStats.Type == itemStatsType)
                    {
                        statValue += itemStats.Value;
                    }
                }
            }

            return statValue;
        }
    }
}