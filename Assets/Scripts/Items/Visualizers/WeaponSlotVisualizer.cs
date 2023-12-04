using DungeonAndDemons.ScriptableObjects.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    public class WeaponSlotVisualizer : ItemSlotVisualizer<WeaponItem>
    {
        protected override ItemType SlotType => ItemType.Weapon;
    }
}