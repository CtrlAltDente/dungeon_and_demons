using DungeonAndDemons.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Characters
{
    [Serializable]
    public struct CharacterStats
    {
        public CharacterVisualConfiguration CharacterVisualConfiguration;
        public CharacterCharacteristics CharacterCharacteristics;
        public CharacterItems CharacterItems;
    }
}