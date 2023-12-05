using DungeonAndDemons.Interfaces;
using DungeonAndDemons.Items;
using DungeonAndDemons.ScriptableObjects.Items;
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

        private List<ItemObject> AvailableItems = new List<ItemObject>();

        public void SetPlayerInputData(PlayerInputData playerInputData)
        {
            if (playerInputData.ScrollValue > 0)
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
    }
}