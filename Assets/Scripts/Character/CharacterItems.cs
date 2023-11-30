using DungeonAndDemons.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace DungeonAndDemons.Characters
{
    [Serializable]
    public struct CharacterItems : INetworkSerializable
    {
        private Item Accessory;
        private Item Weapon;
        private Item Suit;

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref Accessory);
            serializer.SerializeValue(ref Weapon);
            serializer.SerializeValue(ref Suit);
        }
    }
}