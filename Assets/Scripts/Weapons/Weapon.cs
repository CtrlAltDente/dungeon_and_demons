using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClansWars.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField]
        protected float _rateOfAttack = 60;
        [SerializeField]
        protected int _damage;
         
        protected bool _canAttack;

        public virtual void Start()
        {
            _canAttack = true;
        }

        public abstract void Attack();

        protected IEnumerator WaitForNextAttack()
        {
            yield return new WaitForSeconds(60f / _rateOfAttack);
            _canAttack = true;
        }
    }
}