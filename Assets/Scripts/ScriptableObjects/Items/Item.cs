using DungeonAndDemons.Items;
using DungeonAndDemons.ScriptableObjects.Modifiers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.ScriptableObjects.Items
{
    [CreateAssetMenu(fileName = "Item_", menuName = "Scriptable Objects/Items/Item", order = 1)]
    public class Item : ScriptableObject
    {
        public ItemType Type;
        public ItemModel Model;
        public List<Modifier> Modifiers;
    }
}