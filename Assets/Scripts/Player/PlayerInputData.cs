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
        public bool IsPrimaryAttack;
        public bool IsSecondaryAttack;
        public bool IsRoll;
        public float ScrollValue;

        public PlayerInputData(ulong playerId ,Vector2 movementVector, bool isPrimaryAttack, bool isSecondaryAttack, bool isRoll, float scrollValue)
        {
            PlayerId = playerId;
            MovementVector = movementVector;
            IsPrimaryAttack = isPrimaryAttack;
            IsSecondaryAttack = isSecondaryAttack;
            IsRoll = isRoll;
            ScrollValue = scrollValue;
        }

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref PlayerId);
            serializer.SerializeValue(ref MovementVector);
            serializer.SerializeValue(ref IsPrimaryAttack);
            serializer.SerializeValue(ref IsSecondaryAttack);
            serializer.SerializeValue(ref IsRoll);
            serializer.SerializeValue(ref ScrollValue);
        }
    }
}