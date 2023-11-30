using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    public class CharacterItemSystem : MonoBehaviour
    {
        public List<IItemType> AvailableItems;

        public ItemSlot[] Slots;

        public void PickupAvailableItem()
        {
            if (AvailableItems.Count > 0)
            {
                SetItem(AvailableItems[0].ItemInfo);
            }
        }

        public void SetItem(ItemInfo itemInfo)
        {
            foreach (ItemSlot slot in Slots)
            {
                if (slot.SlotType == itemInfo.Type)
                {
                    slot.DropItem();
                    slot.SetItem(itemInfo);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<IItemType>() != null)
            {
                AvailableItems.Add(other.gameObject.GetComponent<IItemType>());
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<IItemType>() != null)
            {
                AvailableItems.Remove(other.gameObject.GetComponent<IItemType>());
            }
        }
    }
}