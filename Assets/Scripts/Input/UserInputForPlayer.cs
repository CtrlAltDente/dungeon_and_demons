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

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(2f);
            InitializeInput();
        }

        private void Update()
        {
            UpdateInputForPlayer();
        }

        public void InitializeInput()
        {
            if (_playerState.IsOwner || !NetworkManager.Singleton.IsClient)
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
            if (_playerState.IsOwner && _currentInputType != null)
            {
                _playerState.SetInput(_currentInputType.GetPlayerInputData());
            }
        }
    }
}
