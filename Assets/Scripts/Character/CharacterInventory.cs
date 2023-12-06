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

        public void SetItem(ItemObject itemObject)
        {
            foreach (ItemSlot slot in _slots)
            {
                if (slot.ItemType == itemObject.Item.Type)
                {
                    slot.Item = itemObject.Item;
                    OnItemSlotUpdated?.Invoke(slot);
                }
            }
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