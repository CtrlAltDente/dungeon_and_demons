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
        private Item _itemPrefab;

        public ItemPreset ItemPreset;

        private void Start()
        {
            SpawnPrefab(ItemPreset);
        }

        public void SpawnPrefab(ItemPreset itemPreset)
        {
            ItemObject spawnedItemObject = Instantiate(_itemObject, transform.position, Quaternion.identity, null);

            Item spawnedItem = spawnedItemObject.gameObject.AddComponent<Item>();

            spawnedItem.Type = itemPreset.Type;
            spawnedItem.Model = itemPreset.Model;
            spawnedItem.Modifiers = itemPreset.Modifiers;

            spawnedItemObject.Item = spawnedItem;
        }
    }

    [Serializable]
    public struct ItemPreset
    {
        public ItemType Type;
        public ItemModel Model;
        public List<Modifier> Modifiers;

        public ItemPreset(ItemType itemType, ItemModel itemModel, List<Modifier> modifiers)
        {
            Type = itemType;
            Model = itemModel;
            Modifiers = modifiers;
        }
    }
}