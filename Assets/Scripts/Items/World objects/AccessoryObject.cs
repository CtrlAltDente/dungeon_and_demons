using DungeonAndDemons.ScriptableObjects.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    public class AccessoryObject : ItemObject<AccessoryItem>
    {
        public override ItemType Type => ItemType.Accessory;
    }
}