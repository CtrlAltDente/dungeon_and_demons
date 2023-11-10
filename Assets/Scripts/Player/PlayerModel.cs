using ClansWars.Animations;
using ClansWars.Interfaces;
using ClansWars.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ClansWars.Player
{
    public class PlayerModel : MonoBehaviour, IPlayerLogicPart
    {
        [SerializeField]
        private Transform _modelParentObject;
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private ModelAnimations _modelAnimations;

        [SerializeField]
        private PlayerMovement _playerMovement;

        public void SetPlayerInputData(PlayerInputData playerInputData)
        {
            _animator.SetBool("IsMoving", playerInputData.MovementVector.magnitude > 0.1f);
            _animator.SetBool("IsPrimaryAttack", playerInputData.IsPrimaryAttack);
            _animator.SetBool("IsRoll", playerInputData.IsRoll);

            SetFixedMovement(playerInputData);
        }

        private void SetFixedMovement(PlayerInputData playerInputData)
        {
            playerInputData.MovementVector = _animator.GetBool("InMovement") ? playerInputData.MovementVector : Vector2.zero;
            playerInputData.IsRoll = _animator.GetBool("InRoll");

            _playerMovement.SetPlayerInputData(playerInputData);
        }
    }
}