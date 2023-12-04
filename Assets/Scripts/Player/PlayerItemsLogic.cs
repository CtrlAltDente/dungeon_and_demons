using DungeonAndDemons.Interfaces;
using DungeonAndDemons.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonAndDemons.Player
{
    public class PlayerItemsLogic : MonoBehaviour, IPlayerLogicPart
    {
        public UnityEvent<ItemObject<IItemBase>> OnItemPicked;

        private List<ItemObject<IItemBase>> AvailableItems;

        public void SetPlayerInputData(PlayerInputData playerInputData)
        {
            if(playerInputData.ScrollValue > 0)
            {
                PickupItem();
            }
        }

        private void PickupItem()
        {
            if (AvailableItems.Count > 0)
            {
                OnItemPicked?.Invoke(AvailableItems[0]);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            ItemObject<IItemBase> possibleItem = other.GetComponent<ItemObject<IItemBase>>();

            if (possibleItem != null)
            {
                if (!AvailableItems.Contains(possibleItem))
                {
                    AvailableItems.Add(possibleItem);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            ItemObject<IItemBase> possibleItem = other.GetComponent<ItemObject<IItemBase>>();

            if (possibleItem != null)
            {
                if (AvailableItems.Contains(possibleItem))
                {
                    AvailableItems.Remove(possibleItem);
                }
            }
        }
    }
}