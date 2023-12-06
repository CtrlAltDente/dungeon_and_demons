using DungeonAndDemons.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    [Serializable]
    public struct Item
    {
        public ItemType Type;
        public ItemModel Model;
        public List<Modifier> Modifiers;

        public Item(ItemType type, ItemModel model, List<Modifier> modifiers)
        {
            Type = type;
            Model = model;
            Modifiers = modifiers;
        }
    }
}