using DungeonAndDemons.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Items/Item Type/Accessory", fileName = "Accessory_", order = 0)]
    public class AccessoryItem : ScriptableObject
    {
        public string Name;
        public int BlockValue;
        public ItemModel ItemModel;
    }
}