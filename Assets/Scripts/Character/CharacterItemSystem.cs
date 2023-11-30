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
            if (other.gameObject.GetComponent<WorldItem>() != null)
            {
                SetItem(other.gameObject.GetComponent<WorldItem>().ItemInfo);
                //AvailableItems.Add(other.gameObject.GetComponent<Item>());
            }
        }

        private void OnTriggerExit(Collider other)
        {
            /*if (other.gameObject.GetComponent<Item>() != null)
            {
                AvailableItems.Remove(other.gameObject.GetComponent<Item>());
            }*/
        }
    }
}