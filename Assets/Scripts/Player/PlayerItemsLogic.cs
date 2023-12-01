using DungeonAndDemons.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonAndDemons.Player
{
    public class PlayerItemsLogic : MonoBehaviour
    {
        public UnityEvent<ItemWorldObject> OnItemPicked;

        public ItemSlot WeaponSlot;
        public ItemSlot AccessorySlot;
        public ItemSlot SuitSlot;

        [SerializeField]
        private List<ItemWorldObject> ItemsAroudPlayer;

        public void PickupItem()
        {
            if (ItemsAroudPlayer.Count > 0)
            {
                ItemWorldObject itemWorldObject = ItemsAroudPlayer[0];
                OnItemPicked.Invoke(itemWorldObject);
            }
        }

        public void DropItem(ItemSlot itemSlot)
        {
            itemSlot.DropItem();
        }

        private void OnTriggerEnter(Collider other)
        {
            ItemWorldObject possibleWorldObject = other.GetComponent<ItemWorldObject>();

            if (possibleWorldObject != null)
            {
                if (!ItemsAroudPlayer.Contains(possibleWorldObject))
                {
                    ItemsAroudPlayer.Add(possibleWorldObject);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            ItemWorldObject possibleWorldObject = other.GetComponent<ItemWorldObject>();

            if (possibleWorldObject != null)
            {
                if (ItemsAroudPlayer.Contains(possibleWorldObject))
                {
                    ItemsAroudPlayer.Remove(possibleWorldObject);
                }
            }
        }
    }
}