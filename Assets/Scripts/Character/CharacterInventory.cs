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
                if(slot.ItemType == item.Type)
                {
                    slot.Item = item;
                    OnItemSlotUpdated?.Invoke(slot);
                }
            }
        }

        public void DropItem(int slotIndex)
        {
            _slots[slotIndex].Item = new Item(ItemType.None, null, null);
            OnItemSlotUpdated?.Invoke(_slots[slotIndex]);
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