using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClansWars.Animations
{
    public class StateParameterSetter : StateMachineBehaviour
    {
        public Parameter<bool>[] BoolParameters;

        public static int OnStateEnterCalls;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            OnStateEnterCalls++;
            SetParameters(animator);
        }

        private void SetParameters(Animator animator)
        {
            foreach (Parameter<bool> boolParameter in BoolParameters)
            {
                animator.SetBool(boolParameter.Name, boolParameter.Value);
            }
        }
    }

    [Serializable]
    public struct Parameter<T>
    {
        public string Name;
        public T Value;
    }
}