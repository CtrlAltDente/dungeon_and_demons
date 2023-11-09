using ClansWars.Player;
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
         
        public bool CanAttack;

        public virtual void Start()
        {
            CanAttack = true;
        }

        public void Attack(float timeToAttackMoment, float timeOfAnimation)
        {
            if(CanAttack)
            {
                CanAttack = false;
                StartCoroutine(DoAttackOperations(timeToAttackMoment));
                StartCoroutine(WaitForNextAttack(timeOfAnimation));
            }
        }

        protected abstract IEnumerator DoAttackOperations(float timeToAttackMoment);

        protected IEnumerator WaitForNextAttack(float timeOfAnimation)
        {
            yield return new WaitForSeconds(timeOfAnimation);
            CanAttack = true;
        }
    }
}