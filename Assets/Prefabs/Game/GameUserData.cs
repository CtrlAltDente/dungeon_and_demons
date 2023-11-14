using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Game
{
    [Serializable]
    public struct GameUserData
    {
        public int MapIndex;
        public int CharacterIndex;

        public GameUserData(int mapIndex, int characterIndex)
        {
            MapIndex = mapIndex;
            CharacterIndex = characterIndex;
        }
    }
}