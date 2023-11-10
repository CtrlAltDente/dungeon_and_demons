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

        public void SetPlayerInputData(PlayerInputData playerInputData)
        {
            _animator.SetBool("IsMoving", playerInputData.MovementVector.magnitude > 0.5f);
            _animator.SetBool("IsPrimaryAttack", playerInputData.IsPrimaryAttack);
            _animator.SetBool("IsSecondaryAttack", playerInputData.IsSecondaryAttack);
            _animator.SetBool("IsRoll", playerInputData.IsRoll);
        }
    }
}