using ClansWars.Interfaces;
using ClansWars.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClansWars.Player
{
    public class PlayerAttack : MonoBehaviour, IPlayerLogicPart
    {
        [SerializeField]
        private Weapon _currentWeapon;

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
            if(_currentPlayerInputData.IsAttack)
            {
                _currentWeapon.Attack();
            }
        }
    }
}