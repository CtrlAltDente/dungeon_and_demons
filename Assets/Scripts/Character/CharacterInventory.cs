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

        public ItemSlot[] Slots => _slots;

        [SerializeField]
        private ItemSlot[] _slots;

        private void Start()
        {
            SetupItemsAtStart();
        }

        public void SetItem(Item item)
        {
            foreach (ItemSlot slot in _slots)
            {
                if(slot.ItemType == item.SlotType)
                {
                    slot.Item = item;
                    OnItemSlotUpdated?.Invoke(slot);
                }
            }
        }

        public ItemSlot GetSlotForItem(Item item)
        {
            foreach (ItemSlot slot in _slots)
            {
                if (slot.ItemType == item.SlotType)
                {
                    return slot;
                }
            }

            return null;
        }

        private void SetupItemsAtStart()
        {
            foreach (ItemSlot slot in _slots)
            {
                OnItemSlotUpdated?.Invoke(slot);
            }
        }
    }
}