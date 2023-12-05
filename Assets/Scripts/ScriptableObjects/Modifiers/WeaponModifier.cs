using DungeonAndDemons.Items;
using DungeonAndDemons.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.ScriptableObjects.Modifiers
{
    [Serializable]
    public class WeaponModifier : Modifier
    {
        public override string ModifierName => "Weapon";
        public override string ModifierDescription => "Damage";

        public override ModifierType ModifierType => ModifierType.Item;

        public override void ApplyModifier(PlayerCharacter playerCharacter)
        {
            
        }
    }
}