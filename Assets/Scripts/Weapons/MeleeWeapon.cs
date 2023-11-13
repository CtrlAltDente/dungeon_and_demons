using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClansWars.Weapons
{
    public class MeleeWeapon : Weapon
    {
        public float AttackRange;

        [SerializeField]
        private Collider _collider;

        public override void Attack()
        {
            _collider.enabled = true;
            StartCoroutine(DisableCollider());
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<IDamagable>() != null)
            {
                other.GetComponent<IDamagable>().TakeDamage(_damage);
            }
        }

        private IEnumerator DisableCollider()
        {
            yield return new WaitForSeconds(0.1f);
            _collider.enabled = false;
        }
    }
}