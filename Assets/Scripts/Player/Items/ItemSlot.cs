using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    public class ItemSlot : MonoBehaviour
    {
        public GameObject Item;
        public ItemInfo SlotItemInfo;
        public ItemType SlotType;

        public void DropItem()
        {
            SlotItemInfo = default;
        }

        public void SetItem(ItemInfo itemInfo)
        {
            SlotItemInfo = itemInfo;
        }
    }
}