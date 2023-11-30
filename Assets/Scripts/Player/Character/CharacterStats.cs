using DungeonAndDemons.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace DungeonAndDemons.Characters
{
    [Serializable]
    public struct CharacterStats : INetworkSerializable
    {
        public CharacterVisualConfiguration CharacterVisualConfiguration;
        public CharacterCharacteristics CharacterCharacteristics;
        public CharacterItems CharacterItems;

        public CharacterStats(CharacterVisualConfiguration characterVisualConfiguration, CharacterCharacteristics characterCharacteristics, CharacterItems characterItems)
        {
            CharacterVisualConfiguration = characterVisualConfiguration;
            CharacterCharacteristics = characterCharacteristics;
            CharacterItems = characterItems;
        }

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref CharacterVisualConfiguration);
            serializer.SerializeValue(ref CharacterCharacteristics);
            serializer.SerializeValue(ref CharacterItems);
        }
    }
}