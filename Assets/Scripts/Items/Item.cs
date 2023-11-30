using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    [Serializable]
    public struct Item : INetworkSerializable
    {
        public ItemInfo ItemInfo;

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref ItemInfo);
        }
    }
}