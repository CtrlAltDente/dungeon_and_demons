using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace ClansWars.Player
{
    [Serializable]
    public struct PlayerInputData : INetworkSerializable
    {
        public ulong PlayerId;
        public Vector2 MovementVector;
        public bool IsAttack;

        public PlayerInputData(ulong playerId ,Vector2 movementVector, bool isAttack)
        {
            PlayerId = playerId;
            MovementVector = movementVector;
            IsAttack = isAttack;
        }

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref PlayerId);
            serializer.SerializeValue(ref MovementVector);
            serializer.SerializeValue(ref IsAttack);
        }
    }
}