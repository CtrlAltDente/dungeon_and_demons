using DungeonAndDemons.Items;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Player
{
    public class PlayerStats : MonoBehaviour
    {
        public PlayerCharacter _playerCharacter;

        public int AttackDamage;
        public int ArmorValue;

        private void Update()
        {
            CalculateValues();
        }

        private void CalculateValues()
        {
            int attackDamageStats = GetStatsValueInItems(ItemStatsName.Attack);
            AttackDamage = attackDamageStats + _playerCharacter.CharacterAttributes.Strength * 2;

            int armorDamageStats = GetStatsValueInItems(ItemStatsName.Armor);
            ArmorValue = armorDamageStats;
        }

        private int GetStatsValueInItems(ItemStatsName itemStatsName)
        {
            int statsValue = 0;

            foreach(ItemSlot slot in _playerCharacter.CharacterInventory.Slots)
            {
                foreach(ItemStats itemStats in slot.Item.Stats)
                {
                    if (itemStats.StatsName == itemStatsName)
                    {
                        statsValue += itemStats.StatsValue;
                    }
                }
            }

            return statsValue;
        }
    }
}