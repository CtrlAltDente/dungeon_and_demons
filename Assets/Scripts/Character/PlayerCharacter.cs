using DungeonAndDemons.Interfaces;
using DungeonAndDemons.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonAndDemons.Player
{
    public class PlayerCharacter : MonoBehaviour
    {
        public UnityEvent<ItemSlot> OnItemSlotUpdated;

        [SerializeField]
        public PlayerInfo PlayerInfo;

        private void Start()
        {
            SetupItemsAtStart();
        }

        private void SetupItemsAtStart()
        {
            foreach(ItemSlot itemSlot in PlayerInfo.ItemSlots)
            {
                OnItemSlotUpdated?.Invoke(itemSlot);
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