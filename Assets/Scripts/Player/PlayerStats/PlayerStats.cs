using DungeonAndDemons.Character;
using DungeonAndDemons.Items;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Player
{
    public class PlayerStats : MonoBehaviour
    {
        public CharacterComponents _characterComponents;

        public int AttackDamage;
        public int ArmorValue;

        public StatsCalculator[] StatsCalculators;

        private void Update()
        {
            CalculateValues();
        }

        private void CalculateValues()
        {
            foreach (StatsCalculator statsCalculator in StatsCalculators)
            {
                statsCalculator.CalculateStats(this, _characterComponents);
            }
        }
    }
}