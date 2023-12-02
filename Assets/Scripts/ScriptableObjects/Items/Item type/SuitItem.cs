using DungeonAndDemons.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Items/Item Type/Suit", fileName = "Suit_", order = 1)]
    public class SuitItem : ScriptableObject
    {
        public string Name;
        public int ArmorValue;
        public ItemModel Model;
    }
}