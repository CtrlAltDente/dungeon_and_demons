using DungeonAndDemons.ScriptableObjects.Modifiers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Character
{
    [Serializable]
    public class ModifierStats
    {
        public List<Modifier> AttackDamageModifiers;
        public List<Modifier> ArmorModifiers;

        public int AttackDamage => GetAttackDamage();
        public int ArmorValue => GetArmorValue();

        private int GetAttackDamage()
        {
            int damage = GetModifiersValue(AttackDamageModifiers);

            damage = damage < 0 ? 0 : damage;

            return damage;
        }

        private int GetArmorValue()
        {
            return GetModifiersValue(ArmorModifiers);
        }

        private int GetModifiersValue(List<Modifier> modifiers)
        {
            int value = 0;
            
            foreach (Modifier modifier in modifiers)
            {
                value += modifier.ModifierValue;
            }

            return value;
        }
    }
}