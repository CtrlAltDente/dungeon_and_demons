using DungeonAndDemons.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    [CreateAssetMenu(fileName = "Accessory_", menuName = "Scriptable Objects/Items/Accessory Item", order = 5)]
    public class AccessoryItem : ScriptableObject
    {
        public string Name;
        public int BlockValue;
        public ItemModel ItemModel;
    }
}