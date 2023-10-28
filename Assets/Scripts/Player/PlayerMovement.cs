using ClansWars.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClansWars.Player
{
    public class PlayerMovement : MonoBehaviour, IPlayerLogicPart
    {
        [SerializeField]
        private float _movementSpeed;
        [SerializeField]
        private float _rotationSpeed;

        [SerializeField]
        private Transform _playerTransform;

        [SerializeField]
        private PlayerInputData _currentPlayerInput = new PlayerInputData(0, Vector2.zero, false);

        private void Update()
        {
            Move(_currentPlayerInput);
        }

        public void SetPlayerInputData(PlayerInputData playerInputData)
        {
            _currentPlayerInput = playerInputData;
        }

        private void Move(PlayerInputData playerInputData)
        {
            if (playerInputData.MovementVector != Vector2.zero)
            {
                Vector3 movementVector3 = new Vector3(playerInputData.MovementVector.x, 0f, playerInputData.MovementVector.y);
                _playerTransform.rotation = Quaternion.RotateTowards(_playerTransform.rotation, Quaternion.LookRotation(movementVector3), _rotationSpeed * Time.deltaTime);
                _playerTransform.position += _playerTransform.forward * _movementSpeed * Time.deltaTime;
            }
        }
    }
}