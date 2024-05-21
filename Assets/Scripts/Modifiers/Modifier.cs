using DungeonAndDemons.Enums;
using System;

namespace DungeonAndDemons.ModifiersLogic
{
    [Serializable]
    public class Modifier
    {
        public ModifierType ModifierType;
        public int ModifierValue;
    }
}