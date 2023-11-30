using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    public class CharacterItemSystem : MonoBehaviour
    {
        public List<WorldItem> AvailableItems;

        public ItemSlot[] Slots;

        public void PickupAvailableItem()
        {
            if (AvailableItems.Count > 0)
            {
                WorldItem item = AvailableItems[0];
                AvailableItems.Remove(item);
                SetItem(item.ItemInfo);
                Destroy(item.gameObject);
            }
        }

        public void SetItem(ItemInfo itemInfo)
        {
            foreach (ItemSlot slot in Slots)
            {
                if (slot.SlotType == itemInfo.Type)
                {
                    if(slot.HasItem)
                    {
                        slot.DropItem();
                    }

                    slot.SetItem(itemInfo);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<WorldItem>() != null)
            {
                AvailableItems.Add(other.gameObject.GetComponent<WorldItem>());
                PickupAvailableItem();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<WorldItem>() != null)
            {
                if (AvailableItems.Contains(other.gameObject.GetComponent<WorldItem>()))
                {
                    AvailableItems.Remove(other.gameObject.GetComponent<WorldItem>());
                }
            }
        }
    }
}