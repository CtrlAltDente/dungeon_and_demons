using DungeonAndDemons.Interfaces;
using DungeonAndDemons.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonAndDemons.Player
{
    public class PlayerItemsLogic : MonoBehaviour, IPlayerLogicPart
    {
        public UnityEvent<ItemObject> OnItemPicked;

        [SerializeField]
        private List<ItemObject> AvailableItems = new List<ItemObject>();

        public void SetPlayerInputData(PlayerInputData playerInputData)
        {
            if (playerInputData.ScrollValue > 0)
            {
                Debug.Log("PICK!");
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

        private void DropItem()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            ItemObject itemObject = other.GetComponent<ItemObject>();

            if (itemObject)
            {
                if (!AvailableItems.Contains(itemObject))
                {
                    AvailableItems.Add(itemObject);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            ItemObject itemObject = other.GetComponent<ItemObject>();

            if(itemObject)
            {
                if(AvailableItems.Contains(itemObject))
                {
                    AvailableItems.Remove(itemObject);
                }
            }
        }
    }
}