using DungeonAndDemons.Character;
using DungeonAndDemons.Interfaces;
using DungeonAndDemons.Items;
using DungeonAndDemons.Player.Items;
using DungeonAndDemons.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonAndDemons.Player
{
    public class PlayerItemsLogic : MonoBehaviour, IPlayerLogicPart
    {
        [SerializeField]
        private PlayerItemsPicker _playerItemsPicker;

        [SerializeField]
        private PlayerItemsDropper _playerItemsDropper;

        public void SetPlayerInputData(PlayerInputData playerInputData)
        {
            if (playerInputData.IsPickupItem)
            {
                _playerItemsPicker.PickupAvailableItem();
            }
        }
    }
}