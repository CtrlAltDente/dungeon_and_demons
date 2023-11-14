using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ClansWars.Animations
{
    public class CharacterAnimationsEvents : MonoBehaviour
    {
        public UnityEvent OnPrimaryAttackEvent;

        public UnityEvent OnSecondaryAttackEvent;

        public UnityEvent<bool> OnRollEvent;

        public void RaiseAnimationAttacksEvents()
        {
            OnPrimaryAttackEvent?.Invoke();
        }
    }
}