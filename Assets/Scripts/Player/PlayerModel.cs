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
        private PlayerAttack _playerAttack;

        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private ModelAnimations _modelAnimations;

        public void SetPlayerInputData(PlayerInputData playerInputData)
        {
            SetMovementValue(playerInputData);
        }

        public AttackAnimationConfig PlayAttackAnimation()
        {
            AttackAnimationConfig attackAnimationConfig = _modelAnimations.RandomAttackAnimation;
            _animator.Play(attackAnimationConfig.AnimationClip.name);
            return attackAnimationConfig;
        }

        private void SetMovementValue(PlayerInputData playerInputData)
        {
            if (!_playerAttack.InAttack)
            {
                _animator.SetBool("IsMoving", playerInputData.MovementVector.magnitude > 0.1f);
            }
            else
            {
                _animator.SetBool("IsMoving", false);
            }
        }
    }
}