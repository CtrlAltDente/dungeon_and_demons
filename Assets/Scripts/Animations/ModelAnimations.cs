using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ClansWars.Animations
{
    public class ModelAnimations : MonoBehaviour
    {
        public UnityEvent OnAnimationAttackEvent;
        
        public void RaiseAnimationAttacksEvents()
        {
            OnAnimationAttackEvent?.Invoke();
        }
    }
}