using ClansWars.Input;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace ClansWars.Player
{
    public class PlayerState : NetworkBehaviour
    {
        [SerializeField]
        private bool _isAlive = true;
        [SerializeField]
        private bool _isMoving = false;

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private PlayerInput _playerInput;

        public void UpdateInput(PlayerInputData playerInputData)
        {
            _playerInput.SetPlayerInputData(playerInputData);
            _isMoving = playerInputData.MovementVector.magnitude > 0.1f;

            _animator.SetBool("IsMoving", _isMoving);
        }
    }
}