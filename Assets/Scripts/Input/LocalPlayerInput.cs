using ClansWars.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ClansWars.Input
{
    public class LocalPlayerInput : PlayerInput
    {
        [SerializeField]
        private InputActionReference _movementPlayerInputActionReference;
        [SerializeField]
        private InputActionReference _attackPlayerInputActionReference;

        protected override void ApplyInputToThePlayerLogicParts()
        {
            Vector2 movementVector = _movementPlayerInputActionReference.action.ReadValue<Vector2>();
            bool isAttack = _attackPlayerInputActionReference.action.IsPressed();

            PlayerInputData playerInputData = new PlayerInputData(movementVector, isAttack);

            OnPlayerInputDataReady?.Invoke(playerInputData);
        }
    }
}