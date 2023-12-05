using System;

namespace DungeonAndDemons.Items
{
    [Serializable]
    public class Modifier
    {
        public int ModifierValue;

        public string ModifierName;
        public string ModifierDescription;

        public ModifierType ModifierType;
    }
}