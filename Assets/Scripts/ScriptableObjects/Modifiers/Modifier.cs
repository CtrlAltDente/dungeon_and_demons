using DungeonAndDemons.Items;
using DungeonAndDemons.Player;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.ScriptableObjects.Modifiers
{
    [Serializable]
    public abstract class Modifier
    {
        public abstract string ModifierName { get; }
        public abstract string ModifierDescription { get; }

        public abstract ModifierType ModifierType { get; }

        public abstract void ApplyModifier(PlayerCharacter playerCharacter);
    }
}