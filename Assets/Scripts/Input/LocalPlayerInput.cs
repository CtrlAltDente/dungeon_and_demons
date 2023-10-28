using ClansWars.Player;
using System.Collections;
using System.Collections.Generic;
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

        private void Update()
        {
            UpdateInputAtPlayerState();
        }

        private void UpdateInputAtPlayerState()
        {
            Vector2 movementVector = _movementPlayerInputActionReference.action.ReadValue<Vector2>();
            bool isAttack = _attackPlayerInputActionReference.action.IsPressed();

            PlayerInputData playerInputData = new PlayerInputData(movementVector, isAttack);

            _playerState.UpdateInput(playerInputData);
        }
    }
}