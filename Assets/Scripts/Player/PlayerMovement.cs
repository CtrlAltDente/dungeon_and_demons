using ClansWars.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClansWars.Player
{
    public class PlayerMovement : MonoBehaviour, IPlayerLogicPart
    {
        [SerializeField]
        private Transform _playerTransform;
        [SerializeField]
        private PlayerAttack _playerAttack;

        [SerializeField]
        private PlayerInputData _currentPlayerInput = new PlayerInputData(0, Vector2.zero, false, false, false, 0);

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
            _isRolling = playerInputData.IsRoll;                        //roll has more priority because roll blocking input (usually in games)

            if (!_isRolling)
            {
                _currentPlayerInput = playerInputData;
            }
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