using DungeonAndDemons.Enums;
using System;

namespace DungeonAndDemons.Modifiers
{
    [Serializable]
    public struct Modifier
    {
        public ModifierType Type;
        public int Value;
    }
}