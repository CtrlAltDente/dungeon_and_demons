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
        private List<Transform> _bulletSpawnPositions;

        [SerializeField]
        private Bullet _bulletPrefab;

        private float RandomAngleValue => Random.Range(-_spreadAngle, _spreadAngle);

        public override void Attack()
        {
            if(_canAttack)
            {
                _canAttack = false;
                InstantiateBullets();
                StartCoroutine(WaitForNextAttack());
            }
        }

        private void InstantiateBullets()
        {
            foreach(Transform spawnPosition in _bulletSpawnPositions)
            {
                Quaternion randomAngle = Quaternion.Euler(RandomAngleValue, RandomAngleValue, RandomAngleValue);
                Instantiate(_bulletPrefab, spawnPosition.position, spawnPosition.rotation * randomAngle, null);
            }
        }
    }
}