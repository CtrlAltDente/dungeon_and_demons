using ClansWars.Interfaces;
using ClansWars.Player;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ClansWars.Input
{
    public class KeyboardInputType : MonoBehaviour, IInputType
    {
        [SerializeField]
        private InputActionReference _movementPlayerInputActionReference;
        [SerializeField]
        private InputActionReference _attackPlayerInputActionReference;

        public PlayerInputData GetPlayerInputData()
        {
            Vector2 movementVector = _movementPlayerInputActionReference.action.ReadValue<Vector2>();
            bool isAttack = _attackPlayerInputActionReference.action.IsPressed();

            ulong id = NetworkManager.Singleton.IsHost || NetworkManager.Singleton.IsClient ? NetworkManager.Singleton.LocalClientId : 0;

            PlayerInputData playerInputData = new PlayerInputData(id, movementVector, isAttack);

            return playerInputData;
        }
    }
}