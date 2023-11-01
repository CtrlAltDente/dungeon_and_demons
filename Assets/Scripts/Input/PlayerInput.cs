using ClansWars.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ClansWars.Input
{
    public class PlayerInput : MonoBehaviour
    {
        public UnityEvent<PlayerInputData> OnPlayerInputDataReady;

        public void SetPlayerInputData(PlayerInputData playerInputData)
        {
            OnPlayerInputDataReady?.Invoke(playerInputData);
        }
    }
}