using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace DungeonAndDemons.Characters
{
    [Serializable]
    public struct CharacterCharacteristics : INetworkSerializable
    {
        public int Strength;        //hp and attack power
        public int Dexterity;       //critical strike chance and enemy attack miss chance
        public int Intelligence;    //mana

        public CharacterCharacteristics(int strength, int dexterity, int intelligence)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref Strength);
            serializer.SerializeValue(ref Dexterity);
            serializer.SerializeValue(ref Intelligence);
        }
    }
}