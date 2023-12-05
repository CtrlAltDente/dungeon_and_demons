using DungeonAndDemons.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonAndDemons.Character
{
    public class CharacterInventory : MonoBehaviour
    {
        public UnityEvent<ItemSlot> OnItemSlotUpdated;

        [SerializeField]
        private ItemSlot[] _slots;

        private void Start()
        {
            SetupItemsAtStart();
        }

        private void SetupItemsAtStart()
        {
            foreach (ItemSlot slot in _slots)
            {
                OnItemSlotUpdated?.Invoke(slot);
            }
        }

        private ItemSlot GetItemSlotByType(ItemType itemType)
        {
            foreach (ItemSlot slot in _slots)
            {
                if (slot.ItemType == itemType)
                {
                    return slot;
                }
            }

            return null;
        }
    }
}