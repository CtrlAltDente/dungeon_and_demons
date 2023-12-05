using DungeonAndDemons.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    public class Item : MonoBehaviour
    {
        public ItemType Type;
        public ItemModel Model;
        public List<Modifier> Modifiers;
    }
}