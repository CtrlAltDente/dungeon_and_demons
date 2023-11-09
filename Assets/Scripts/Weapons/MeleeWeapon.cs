using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClansWars.Weapons
{
    public class MeleeWeapon : Weapon
    {
        protected override IEnumerator DoAttackOperations(float timeToAttackMoment)
        {
            yield return new WaitForSeconds(timeToAttackMoment);
            DamageObjects();
        }

        private void DamageObjects()
        {
            
        }
    }
}