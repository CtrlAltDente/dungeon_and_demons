using ClansWars.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ClansWars.Input
{
    public abstract class PlayerInput : MonoBehaviour
    {
        public UnityEvent<PlayerInputData> OnPlayerInputDataReady;

        protected void Update()
        {
            ApplyInputToThePlayerLogicParts();
        }

        protected abstract void ApplyInputToThePlayerLogicParts();
    }
}