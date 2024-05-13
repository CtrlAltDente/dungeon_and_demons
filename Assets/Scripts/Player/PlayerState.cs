using DungeonAndDemons.Input;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Unity.Netcode;
using UnityEngine;

namespace DungeonAndDemons.Player
{
    public class PlayerState : NetworkBehaviour
    {
        public bool IsAlive = true;

        [SerializeField]
        private PlayerCharacter _playerCharacter;
        [SerializeField]
        private PlayerInput _playerInput;
        
        public override void OnNetworkSpawn()
        {
            base.OnNetworkSpawn();
        }

        [ServerRpc]
        public void SetInputServerRpc(PlayerInputData playerInputData)
        {
            _playerInput.SetPlayerInputData(playerInputData);
        }

        public void SetInput(PlayerInputData playerInputData)
        {
            _playerInput.SetPlayerInputData(playerInputData);
        }
    }
}