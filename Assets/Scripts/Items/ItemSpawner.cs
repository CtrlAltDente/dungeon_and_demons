using DungeonAndDemons.ScriptableObjects;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField]
        private ItemObject _itemObject;

        [SerializeField]
        private Item _itemPreset;

        private void Start()
        {
            SpawnPrefab(_itemPreset);
        }

        public void SpawnPrefab(Item itemPreset)
        {
            ItemObject spawnedItemObject = Instantiate(_itemObject, transform.position, Quaternion.identity, null);

            spawnedItemObject.Item = spawnedItemObject.gameObject.AddComponent<Item>();

            spawnedItemObject.Item.Type = itemPreset.Type;
            spawnedItemObject.Item.Model = itemPreset.Model;
            spawnedItemObject.Item.Modifiers = itemPreset.Modifiers;
        }
    }
}