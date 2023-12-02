using DungeonAndDemons.Interfaces;
using DungeonAndDemons.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    public class ItemObject<T> : MonoBehaviour where T : IItemPreferences
    {
        public ItemInfo Info;
        public T Item;
    }
}