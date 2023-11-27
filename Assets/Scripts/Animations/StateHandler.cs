using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonAndDemons.Animations
{
    public class StateHandler : StateMachineBehaviour
    {
        public UnityEvent OnStateEnterEvent;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log("Raised");
            OnStateEnterEvent?.Invoke();
        }
    }
}