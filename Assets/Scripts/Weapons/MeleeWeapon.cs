using ClansWars.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClansWars.Weapons
{
    public class MeleeWeapon : Weapon
    {
        public override void Attack()
        {
            
        }

        public void DamageCollidersInArea(Collider other)
        {
            if (other.GetComponent<IDamagable>() != null)
            {
                other.GetComponent<IDamagable>().TakeDamage(_damage);
            }
        }
    }
}