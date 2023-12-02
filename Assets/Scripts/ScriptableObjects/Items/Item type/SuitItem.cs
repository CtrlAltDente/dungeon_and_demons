using DungeonAndDemons.Interfaces;
using DungeonAndDemons.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Items/Item Type/Suit", fileName = "Suit_", order = 1)]
    public class SuitItem : ScriptableObject, IItemPreferences
    {
        public int ArmorValue;

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