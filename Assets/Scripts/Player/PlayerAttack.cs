using ClansWars.Interfaces;
using ClansWars.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClansWars.Player
{
    public class PlayerAttack : MonoBehaviour, IPlayerLogicPart
    {
        public bool InAttack => !_currentWeapon.CanAttack;

        [SerializeField]
        private Weapon _currentWeapon;

        [SerializeField]
        protected PlayerModel _playerModel;

        private PlayerInputData _currentPlayerInputData = new PlayerInputData(0, Vector2.zero, false);

        private void Update()
        {
            Attack();
        }

        public void SetPlayerInputData(PlayerInputData playerInputData)
        {
            _currentPlayerInputData = playerInputData;
        }

        public void SetWeapon(Weapon weapon)
        {
            _currentWeapon = weapon;
        }

        private void Attack()
        {
            if(_currentPlayerInputData.IsAttack && _currentWeapon.CanAttack)
            {
                AttackAnimationConfig attackAnimation = _playerModel.PlayAttackAnimation();
                _currentWeapon.Attack(attackAnimation.TimeForAttackMoment, attackAnimation.AnimationClip.length);
            }
        }
    }
}