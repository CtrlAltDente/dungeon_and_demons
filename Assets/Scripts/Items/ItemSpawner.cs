using DungeonAndDemons.ScriptableObjects.Containers;
using DungeonAndDemons.ScriptableObjects.Items;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    public class ItemSpawner : MonoBehaviour
    {
        public ItemInfo Info;

        [SerializeField]
        private AccessoriesContainer _accessoriesContainer;
        [SerializeField]
        private WeaponsContainer _weaponsContainer;
        [SerializeField]
        private SuitsContainer _suitsContainer;

        [SerializeField]
        private AccessoryObject _accessoryObject;
        [SerializeField]
        private WeaponObject _weaponObject;
        [SerializeField]
        private SuitObject _suitObject;
    }
}