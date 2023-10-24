using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClansWars.Weapons
{
    public class AutoGun : Weapon
    {
        [SerializeField]
        private float _spreadAngle;

        [SerializeField]
        private Transform _bulletSpawnPosition;

        [SerializeField]
        private Bullet _bulletPrefab;

        private float RandomAngleValue => Random.Range(-_spreadAngle, _spreadAngle);

        public override void Attack()
        {
            if(_canAttack)
            {
                _canAttack = false;
                Quaternion randomAngle = Quaternion.Euler(RandomAngleValue, RandomAngleValue, RandomAngleValue);
                Instantiate(_bulletPrefab, _bulletSpawnPosition.position, _bulletSpawnPosition.rotation * randomAngle, null);
                StartCoroutine(WaitForNextAttack());
            }
        }
    }
}