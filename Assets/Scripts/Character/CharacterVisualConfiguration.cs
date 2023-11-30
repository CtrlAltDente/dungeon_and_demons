using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace DungeonAndDemons.Characters
{
    [Serializable]
    public struct CharacterVisualConfiguration : INetworkSerializable
    {
        public Color BodyColor;
        public int HairStyleIndex;
        public int EyebrowIndex;
        public int BeardIndex;
        public Color HairColor;
        public int SuitIndex;

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref HairStyleIndex);
            serializer.SerializeValue(ref EyebrowIndex);
            serializer.SerializeValue(ref BeardIndex);
            serializer.SerializeValue(ref HairColor);
            serializer.SerializeValue(ref SuitIndex);
        }
    }
}