using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    [Serializable]
    public struct ItemInfo : INetworkSerializable
    {
        public ItemType Type;
        public int ItemIndex;
        public int ItemValue;

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref Type);
            serializer.SerializeValue(ref ItemIndex);
            serializer.SerializeValue(ref ItemValue);
        }
    }
}