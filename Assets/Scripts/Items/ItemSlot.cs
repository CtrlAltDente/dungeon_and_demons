using DungeonAndDemons.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    [Serializable]
    public class ItemSlot
    {
        public SlotType ItemType;
        public Item Item;
    }
}