using DungeonAndDemons.Interfaces;
using DungeonAndDemons.Network;
using DungeonAndDemons.Player;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DungeonAndDemons.Input
{
    public class PlayerInputDataBridge : MonoBehaviour
    {
        [SerializeField]
        private NetworkPlayersInput _networkPlayersInput;

        [SerializeField]
        private PlayerState _playerState;

        private IInputType _currentInputType;

        [SerializeField]
        private KeyboardInputType _keyboardInputTypePrefab;

        private void Awake()
        {
            InitializeInputType();
        }

        private void Update()
        {
            UpdateInputForPlayer();
        }

        public void SetPlayerState(PlayerState playerState)
        {
            _playerState = playerState;
        }

        public void SetNetworkPlayersInput(NetworkPlayersInput networkPlayersInput)
        {
            _networkPlayersInput = networkPlayersInput;
        }

        private void UpdateInputForPlayer()
        {
            if(NetworkManager.Singleton.IsClient)
            {
                UpdateInputForNetworPlayersInput();
            }
            else
            {
                UpdateInputAtPlayerState();
            }
        }

        private void UpdateInputForNetworPlayersInput()
        {
            if (_networkPlayersInput)
            {
                Debug.Log(_currentInputType.GetPlayerInputData().PlayerId);
                _networkPlayersInput.SetInputToPlayerServerRpc(_currentInputType.GetPlayerInputData());
            }
        }

        private void UpdateInputAtPlayerState()
        {
            if (_playerState)
            {
                _playerState.UpdateInput(_currentInputType.GetPlayerInputData());
            }
        }

        private void InitializeInputType()
        {
            _currentInputType = Instantiate(_keyboardInputTypePrefab, transform);
        }
    }
}
