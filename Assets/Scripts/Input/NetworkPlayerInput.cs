using ClansWars.Network;
using ClansWars.Player;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ClansWars.Input
{
    public class NetworkPlayerInput : MonoBehaviour
    {
        [SerializeField]
        private InputActionReference _movementPlayerInputActionReference;
        [SerializeField]
        private InputActionReference _attackPlayerInputActionReference;

        [SerializeField]
        private PlayerState _playerState;

        public PlayerInputData PlayerInputData;

        private void Start()
        {
            DisableAtLocalMode();
        }

        private void Update()
        {
            if (_playerState.PlayerId.Value == NetworkManager.Singleton.LocalClientId)
            {
                UpdateInputAtPlayerState();
            }
        }

        private void UpdateInputAtPlayerState()
        {
            Vector2 movementVector = _movementPlayerInputActionReference.action.ReadValue<Vector2>();
            bool isAttack = _attackPlayerInputActionReference.action.IsPressed();

            PlayerInputData = new PlayerInputData(NetworkManager.Singleton.LocalClientId, movementVector, isAttack);
            _playerState.SetNetworkInput(PlayerInputData);
        }

        private void DisableAtLocalMode()
        {
            try
            {
                if (NetworkManager.Singleton.IsHost || NetworkManager.Singleton.IsClient)
                {
                    Debug.Log("Connection true, you are in network game");
                }
                else
                {
                    Destroy(this);
                }
            }
            catch
            {
                Destroy(this);
                Debug.Log("NetworkManager is null, you are in local game");
            }
        }
    }
}
