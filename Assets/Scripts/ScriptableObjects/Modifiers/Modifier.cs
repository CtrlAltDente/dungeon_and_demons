using DungeonAndDemons.Items;
using DungeonAndDemons.Player;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.ScriptableObjects.Modifiers
{
    public abstract class Modifier : ScriptableObject
    {
        public int ModifierValue;

        public abstract string ModifierName { get; }
        public abstract string ModifierDescription { get; }

        public abstract void ApplyModifier(PlayerInfo playerInfo);
    }
}