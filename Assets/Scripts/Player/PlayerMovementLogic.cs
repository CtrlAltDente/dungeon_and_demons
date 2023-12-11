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
        private PlayerInputData _currentPlayerInput = default;

        [SerializeField]
        private float _movementSpeed;
        [SerializeField]
        private float _rotationSpeed;

        private bool _isRolling;

        private void Update()
        {
            Move(_currentPlayerInput);
        }

        public void SetPlayerInputData(PlayerInputData playerInputData)
        {
            if (!_isRolling)
            {
                _currentPlayerInput = playerInputData;
            }

            //roll has more priority because roll blocking input (usually in games)
            _isRolling = playerInputData.IsRoll;
        }

        private void Move(PlayerInputData playerInputData)
        {
            if (playerInputData.MovementVector != Vector2.zero)
            {
                Vector3 movementVector3 = new Vector3(playerInputData.MovementVector.x, 0f, playerInputData.MovementVector.y);
                _playerTransform.rotation = Quaternion.RotateTowards(_playerTransform.rotation, Quaternion.LookRotation(movementVector3), _rotationSpeed * Time.deltaTime);
                _playerTransform.position += _playerTransform.forward * _movementSpeed * CalculatedRollSpeed * Time.deltaTime;
            }
        }

        private float CalculatedRollSpeed => _isRolling ? 2 : 1;
    }
}