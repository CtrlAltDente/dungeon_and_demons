using DungeonAndDemons.ScriptableObjects.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    public class SuitSlotVisualizer : ItemSlotVisualizer<WeaponItem>
    {
        protected override ItemType SlotType => ItemType.Suit;
    }
}