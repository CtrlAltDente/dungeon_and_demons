using DungeonAndDemons.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    [CreateAssetMenu(fileName = "Suit_", menuName = "Scriptable Objects/Items/Suit Item", order = 4)]
    public class SuitItem : ScriptableObject
    {
        public string Name;
        public int ArmorValue;
        public ItemModel Model;
    }
}