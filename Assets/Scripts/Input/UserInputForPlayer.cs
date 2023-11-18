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
        private PlayersInput _playersInput;

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
            _currentInputType = Instantiate(_keyboardInputTypePrefab, transform);
        }

        private void UpdateInputForPlayer()
        {
            _playersInput.SetInputToPlayerServerRpc(_currentInputType.GetPlayerInputData());
        }
    }
}
