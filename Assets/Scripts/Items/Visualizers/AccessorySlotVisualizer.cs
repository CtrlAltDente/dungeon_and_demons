using DungeonAndDemons.Interfaces;
using DungeonAndDemons.ScriptableObjects.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    public class AccessorySlotVisualizer : ItemSlotVisualizer<AccessoryItem>
    {
        protected override ItemType SlotType => ItemType.Accessory;
    }
}