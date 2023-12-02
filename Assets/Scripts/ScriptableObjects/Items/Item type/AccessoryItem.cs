using DungeonAndDemons.Interfaces;
using DungeonAndDemons.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.ScriptableObjects.Items
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Items/Item Type/Accessory", fileName = "Accessory_", order = 0)]
    public class AccessoryItem : ScriptableObject, IItemPreferences
    {
        public int BlockValue;

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