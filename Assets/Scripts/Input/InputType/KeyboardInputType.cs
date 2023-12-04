using DungeonAndDemons.Interfaces;
using DungeonAndDemons.Player;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DungeonAndDemons.Input
{
    public class KeyboardInputType : MonoBehaviour, IInputType
    {
        [SerializeField]
        private InputActionReference _movementPlayerInput;
        [SerializeField]
        private InputActionReference _primaryAttackPlayerInput;
        [SerializeField]
        private InputActionReference _secondaryAttackPlayerInput;
        [SerializeField]
        private InputActionReference _rollPlayerInput;
        [SerializeField]
        private InputActionReference _scrollInput;


        public PlayerInputData GetPlayerInputData()
        {
            Vector2 movementVector = _movementPlayerInput.action.ReadValue<Vector2>();
            bool isPrimaryAttack = _primaryAttackPlayerInput.action.IsPressed();
            bool isSecondaryAttack = _secondaryAttackPlayerInput.action.IsPressed();
            bool isRoll = _rollPlayerInput.action.IsPressed();
            float scrollValue = _scrollInput.action.ReadValue<float>();

            ulong id = GetPlayerId();

            PlayerInputData playerInputData = new PlayerInputData(id, movementVector, isPrimaryAttack, isSecondaryAttack, isRoll, scrollValue);

            return playerInputData;
        }

        private ulong GetPlayerId()
        {
            if(NetworkManager.Singleton)
            {
                return NetworkManager.Singleton.IsClient ? NetworkManager.Singleton.LocalClientId : 0;
            }

            return 0;
        }
    }
}