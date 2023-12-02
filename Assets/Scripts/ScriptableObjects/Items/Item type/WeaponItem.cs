using DungeonAndDemons.Interfaces;
using DungeonAndDemons.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Items/Item Type/Weapon", fileName = "Weapon_", order = 2)]
    public class WeaponItem : ScriptableObject, IItemPreferences
    {
        public int DamageValue;

        [SerializeField]
        private string _name;
        [SerializeField]
        private ItemModel _model;

        public string Name
        {
            get
            {
                return _name;
            }
        }
        public ItemModel Model
        {
            get
            {
                return _model;
            }
        }
    }
}