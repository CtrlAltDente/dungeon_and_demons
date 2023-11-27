using DungeonAndDemons.Animations;
using DungeonAndDemons.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonAndDemons.Player
{
    public class PlayerAnimatorLogic : MonoBehaviour, IPlayerLogicPart
    {
        [SerializeField]
        private Transform _modelParentObject;
        [SerializeField]
        private Animator _animator;

        public void SetPlayerInputData(PlayerInputData playerInputData)
        {
            _animator.SetBool("IsMoving", playerInputData.MovementVector.magnitude > 0.3f);
            _animator.SetBool("IsRoll", playerInputData.IsRoll);
            _animator.SetBool("IsPrimaryAttack", playerInputData.IsPrimaryAttack);
            _animator.SetBool("IsSecondaryAttack", playerInputData.IsSecondaryAttack);
        }

        public void SetCharacterAnimator(Animator animator)
        {
            _animator = animator;
        }
    }
}