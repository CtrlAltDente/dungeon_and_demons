using DungeonAndDemons.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonAndDemons.Input
{
    public class PlayerInput : MonoBehaviour
    {
        public UnityEvent<PlayerInputData> OnPlayerInputDataReady;

        public UnityEvent<PlayerInputData> OnFixedPlayerInputDataReady;
        
        public void SetPlayerInputData(PlayerInputData playerInputData)
        {
            OnPlayerInputDataReady?.Invoke(playerInputData);
        }
    }
}