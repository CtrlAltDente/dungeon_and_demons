using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    public class CharacterItemSystem : MonoBehaviour
    {
        public ItemSlot[] Slots;

        public void SetItem(ItemInfo itemInfo)
        {
            foreach(ItemSlot slot in Slots)
            {
                if(slot.SlotType == itemInfo.Type)
                {
                    slot.DropItem();
                    slot.SetItem(itemInfo);
                }
            }
        }
    }
}