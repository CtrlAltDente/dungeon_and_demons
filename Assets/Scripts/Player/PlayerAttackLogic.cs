using DungeonAndDemons.Interfaces;
using DungeonAndDemons.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Player
{
    public class PlayerAttackLogic : MonoBehaviour
    {
        [SerializeField]
        private Weapon _currentWeapon;

        public void SetWeapon(Weapon weapon)
        {
            _currentWeapon = weapon;
        }

        public void Attack()
        {
            Debug.Log("Attack");
            _currentWeapon.Attack();
        }
    }
}