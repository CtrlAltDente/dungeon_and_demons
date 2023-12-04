using DungeonAndDemons.ScriptableObjects.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    public class WeaponObject : ItemObject<WeaponItem>
    {
        public override ItemType Type => ItemType.Weapon;
    }
}