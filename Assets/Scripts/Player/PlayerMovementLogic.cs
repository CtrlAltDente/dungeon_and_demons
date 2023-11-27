using DungeonAndDemons.Animations;
using DungeonAndDemons.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Player
{
    public class PlayerMovementLogic : MonoBehaviour, IPlayerLogicPart
    {
        [SerializeField]
        private Transform _playerTransform;

        [SerializeField]
        private Animator _playerAnimator;

        [SerializeField]
        private PlayerInputData _currentPlayerInput = new PlayerInputData(0, Vector2.zero, false, false, false, 0);

        [SerializeField]
        private float _movementSpeed;
        [SerializeField]
        private float _rotationSpeed;

        [SerializeField]
        private bool _isMoving;
        [SerializeField]
        private bool _isRolling;

        private float CalculatedRollSpeed => _isRolling ? 2 : 1;

        [SerializeField]
        private MovementAnimationState _movementAnimationState;

        private void Update()
        {
            if (_movementAnimationState != null)
            {
                _isMoving = _movementAnimationState.IsMove;
                _isRolling = _movementAnimationState.IsRoll;
            }

            Move(_currentPlayerInput);
        }

        public void SetPlayerInputData(PlayerInputData playerInputData)
        {
            if (!_movementAnimationState.IsRoll)
            {
                _currentPlayerInput = playerInputData;
            }
        }

        public void SetCharacterAnimator(Animator animator)
        {
            _playerAnimator = animator;

            _movementAnimationState = animator.GetBehaviour<MovementAnimationState>();
        }

        private void Move(PlayerInputData playerInputData)
        {
            if (!_movementAnimationState.IsMove)
                return;

            if (playerInputData.MovementVector != Vector2.zero)
            {
                Vector3 movementVector3 = new Vector3(playerInputData.MovementVector.x, 0f, playerInputData.MovementVector.y);
                _playerTransform.rotation = Quaternion.RotateTowards(_playerTransform.rotation, Quaternion.LookRotation(movementVector3), _rotationSpeed * Time.deltaTime);
                _playerTransform.position += _playerTransform.forward * _movementSpeed * CalculatedRollSpeed * Time.deltaTime;
            }
        }

        private void SetIsMoving(bool isMoving)
        {
            Debug.Log($"Setted value is moving {isMoving}");
            _isMoving = isMoving;
        }
        private void SetIsRolling(bool isRolling)
        {
            Debug.Log($"Setted value is roll {isRolling}");
            _isRolling = isRolling;
        }
    }
}