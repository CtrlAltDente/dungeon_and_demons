using DungeonAndDemons.Interfaces;
using DungeonAndDemons.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonAndDemons.Player
{
    public class PlayerCharacter : MonoBehaviour
    {
        public UnityEvent<ItemSlot> OnItemSlotUpdated;

        [SerializeField]
        public PlayerInfo PlayerInfo;

        public void SetItem(ItemObject<IItemPreferences> itemObject)
        {
            try
            {
                ItemSlot itemSlot = GetItemSlotByType(itemObject.Type);
                itemSlot.ItemIndex = itemObject.Info.ItemIndex;

                OnItemSlotUpdated?.Invoke(itemSlot);
            }
            catch(Exception e)
            {
                Debug.LogWarning(e.Message);
            }
        }

        private ItemSlot GetItemSlotByType(ItemType itemType)
        {
            foreach(ItemSlot itemSlot in PlayerInfo.ItemSlots)
            {
                if(itemSlot.ItemType == itemType)
                {
                    return itemSlot;
                }
            }

            return null;
        }
    }
}