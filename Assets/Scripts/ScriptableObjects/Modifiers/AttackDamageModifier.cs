using DungeonAndDemons.Items;
using DungeonAndDemons.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.ScriptableObjects.Modifiers
{
    [CreateAssetMenu(fileName = "Modifier_Weapon", menuName = "Scriptable Objects/Items/Modifiers/Weapon", order = 0)]
    public class AttackDamageModifier : Modifier
    {
        public override string ModifierName => "Weapon";
        public override string ModifierDescription => "Damage";

        public override void ApplyModifier(PlayerInfo playerInfo)
        {
            
        }
    }
}