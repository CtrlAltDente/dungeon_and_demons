using DungeonAndDemons.Character;
using DungeonAndDemons.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Player
{
    [Serializable]
    public struct PlayerInfo
    {
        public CharacterVisualConfig CharacterVisualConfig;

        public string Name;

        public int Level;
        public int CurrentXP;

        public int Strength;
        public int Dexterity;
        public int Intelligence;

        public ItemSlot[] ItemSlots;
    }
}