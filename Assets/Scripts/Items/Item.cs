using DungeonAndDemons.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Items/Item", fileName = "Item_", order = 4)]
    public class Item : ScriptableObject
    {
        public ItemType Type;
        public ItemStats Stats;
        public ItemModel Model;
    }
}