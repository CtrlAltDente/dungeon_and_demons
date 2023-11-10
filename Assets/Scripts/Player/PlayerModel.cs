using ClansWars.Animations;
using ClansWars.Interfaces;
using ClansWars.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClansWars.Player
{
    public class PlayerModel : MonoBehaviour, IPlayerLogicPart
    {
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private ModelAnimations _modelAnimations;

        public void SetPlayerInputData(PlayerInputData playerInputData)
        {
            SetMovementValue(playerInputData);
            SetAttackValue(playerInputData);
        }

        private void SetMovementValue(PlayerInputData playerInputData)
        {
            if (!playerInputData.IsPrimaryAttack)
            {
                _animator.SetBool("IsMoving", playerInputData.MovementVector.magnitude > 0.1f);
            }
            else
            {
                _animator.SetBool("IsMoving", false);
            }
        }

        private void SetAttackValue(PlayerInputData playerInputData)
        {
            _animator.SetBool("IsAttack", playerInputData.IsPrimaryAttack);
        }
    }
}