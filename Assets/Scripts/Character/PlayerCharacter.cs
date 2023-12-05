using DungeonAndDemons.Character;
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

        public CharacterVisual CharacterVisual;

        public CharacterInventory CharacterInventory;
        public CharacterStats CharacterStats;

        private void Start()
        {
            SetupItemsAtStart();
        }

        private void SetupItemsAtStart()
        {
            foreach(ItemSlot slot in CharacterInventory.Slots)
            {
                OnItemSlotUpdated?.Invoke(slot);
            }
        }

        private ItemSlot GetItemSlotByType(ItemType itemType)
        {
            foreach(ItemSlot slot in CharacterInventory.Slots)
            {
                if(slot.ItemType == itemType)
                {
                    return slot;
                }
            }

            return null;
        }
    }
}