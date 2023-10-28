using ClansWars.Player;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ClansWars.Input
{
    public class LocalPlayerInput : MonoBehaviour
    {
        [SerializeField]
        private InputActionReference _movementPlayerInputActionReference;
        [SerializeField]
        private InputActionReference _attackPlayerInputActionReference;

        [SerializeField]
        private PlayerState _playerState;

        private void Start()
        {
            DisableAtNetworkMode();
        }

        private void Update()
        {
            UpdateInputAtPlayerState();
        }

        private void UpdateInputAtPlayerState()
        {
            Vector2 movementVector = _movementPlayerInputActionReference.action.ReadValue<Vector2>();
            bool isAttack = _attackPlayerInputActionReference.action.IsPressed();

            PlayerInputData playerInputData = new PlayerInputData(0, movementVector, isAttack);

            _playerState.UpdateInput(playerInputData);
        }

        private void DisableAtNetworkMode()
        {
            try
            {
                if (NetworkManager.Singleton.IsHost || NetworkManager.Singleton.IsClient)
                {
                    Destroy(this);
                }
                else
                {
                    Debug.Log("Connection false, you are in local game");
                }
            }
            catch
            {
                Debug.Log("NetworkManager is null, you are in local game");
            }
        }
    }
}