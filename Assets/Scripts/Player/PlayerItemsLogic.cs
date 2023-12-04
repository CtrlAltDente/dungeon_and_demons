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
        public UnityEvent<ItemObject<IItemPreferences>> OnItemPicked;

        [SerializeField]
        private List<ItemObject<IItemPreferences>> AvailableItems;

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
            ItemObject<IItemPreferences> possibleItem = other.GetComponent<ItemObject<IItemPreferences>>();

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
            ItemObject<IItemPreferences> possibleItem = other.GetComponent<ItemObject<IItemPreferences>>();

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