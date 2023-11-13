using ClansWars.Input;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace ClansWars.Player
{
    public class PlayerState : NetworkBehaviour
    {
        public bool IsAlive = true;

        [SerializeField]
        private PlayerInput _playerInput;

        public void UpdateInput(PlayerInputData playerInputData)
        {
            if (IsAlive)
            {                
                _playerInput.SetPlayerInputData(playerInputData);
            }
        }

        public void SetModel(int index)
        {

        }
    }
}