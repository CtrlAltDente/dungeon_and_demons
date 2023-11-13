using ClansWars.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClansWars.Weapons
{
    public class MeleeWeapon : Weapon
    {
        [SerializeField]
        private CollisionArea _collisionArea;

        public override void Attack()
        {
            _collisionArea.gameObject.SetActive(true);
            StartCoroutine(DisableCollider());
        }

        private IEnumerator DisableCollider()
        {
            yield return new WaitForSeconds(0.1f);
            _collisionArea.gameObject.SetActive(false);
        }
    }
}