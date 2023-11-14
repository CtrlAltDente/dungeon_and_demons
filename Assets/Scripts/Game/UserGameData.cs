using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace DungeonAndDemons.Game
{
    [Serializable]
    public struct UserGameData : INetworkSerializable
    {
        public int MapIndex;
        public int CharacterIndex;

        public UserGameData(int mapIndex, int characterIndex)
        {
            MapIndex = mapIndex;
            CharacterIndex = characterIndex;
        }

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref MapIndex);
            serializer.SerializeValue(ref CharacterIndex);
        }
    }
}