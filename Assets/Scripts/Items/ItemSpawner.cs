using DungeonAndDemons.Interfaces;
using DungeonAndDemons.ScriptableObjects.Containers;
using DungeonAndDemons.ScriptableObjects.Items;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace DungeonAndDemons.Items
{
    public class ItemSpawner : MonoBehaviour
    {
        public ItemInfo Info;

        [SerializeField]
        private AccessoriesContainer _accessoriesContainer;
        [SerializeField]
        private SuitsContainer _suitsContainer;
        [SerializeField]
        private WeaponsContainer _weaponsContainer;

        [SerializeField]
        private AccessoryObject _accessoryObjectPrefab;
        [SerializeField]
        private SuitObject _suitObjectPrefab;
        [SerializeField]
        private WeaponObject _weaponObjectPrefab;

        private void Start()
        {
            SpawnAccessoryObject(Info);
        }

        public void SpawnAccessoryObject(ItemInfo itemInfo)
        {
            SpawnObject(_accessoryObjectPrefab, _accessoriesContainer, itemInfo);
        }

        public void SpawnSuitObject(ItemInfo itemInfo)
        {
            SpawnObject(_suitObjectPrefab, _suitsContainer, itemInfo);
        }

        public void SpawnWeaponObject(ItemInfo itemInfo)
        {
            SpawnObject(_weaponObjectPrefab, _weaponsContainer, itemInfo);
        }

        private void SpawnObject<T>(ItemObject<T> itemObject, Container<T> container, ItemInfo itemInfo) where T : IItemBase
        {
            var newItemObject = Instantiate(itemObject, transform.position, Quaternion.identity, null);
            newItemObject.Info = itemInfo;
            newItemObject.Item = container.Items[itemInfo.ItemIndex];
        }
    }
}