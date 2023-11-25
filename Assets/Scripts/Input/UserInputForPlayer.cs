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
    public class UserInputForPlayer : MonoBehaviour
    {
        [SerializeField]
        private PlayerState _playerState;

        private IInputType _currentInputType;

        [SerializeField]
        private KeyboardInputType _keyboardInputTypePrefab;

        private void Awake()
        {
            InitializeInput();
        }

        private void Update()
        {
            UpdateInputForPlayer();
        }

        private void InitializeInput()
        {
            if (_playerState.IsOwner)
            {
                _currentInputType = Instantiate(_keyboardInputTypePrefab, transform);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void UpdateInputForPlayer()
        {
            _playerState.UpdateInput(_currentInputType.GetPlayerInputData());
        }
    }
}
