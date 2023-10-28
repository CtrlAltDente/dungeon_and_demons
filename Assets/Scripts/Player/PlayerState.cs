using ClansWars.Input;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace ClansWars.Player
{
    public class PlayerState : NetworkBehaviour
    {
        [SerializeField]
        private NetworkVariable<ulong> _playerId;

        [SerializeField]
        private bool _isAlive = true;

        [SerializeField]
        private PlayerInput _playerInput;

        public void SetId(ulong id)
        {
            _playerId.Value = id;
        }

        public void UpdateInput(PlayerInputData playerInputData)
        {
            _playerInput.SetPlayerInputData(playerInputData);
        }
    }
}