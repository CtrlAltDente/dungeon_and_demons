using ClansWars.Input;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace ClansWars.Player
{
    public class PlayerState : NetworkBehaviour
    {
        public NetworkVariable<ulong> PlayerId = new NetworkVariable<ulong>();

        public NetworkVariable<PlayerInputData> PlayerInputData = new NetworkVariable<PlayerInputData>(default, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

        [SerializeField]
        private bool _isAlive = true;

        [SerializeField]
        private PlayerInput _playerInput;

        public void SetNetworkInput(PlayerInputData playerInputData)
        {

            PlayerInputData.Value = playerInputData;
        }

        public void UpdateInput(PlayerInputData playerInputData)
        {
            _playerInput.SetPlayerInputData(playerInputData);
        }
    }
}