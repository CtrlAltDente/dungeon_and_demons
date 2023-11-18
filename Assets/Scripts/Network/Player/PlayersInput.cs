using DungeonAndDemons.Input;
using DungeonAndDemons.Player;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace DungeonAndDemons.Network
{
    public class PlayersInput : NetworkBehaviour
    {
        [SerializeField]
        private List<PlayerState> _playersStates = new List<PlayerState>();

        private void Start()
        {
            if (NetworkManager.Singleton.IsHost)
            {
                NetworkManager.Singleton.OnClientDisconnectCallback += RemovePlayerState;
            }
        }

        [ServerRpc(RequireOwnership = false)]
        public void SetInputToPlayerServerRpc(PlayerInputData playerInputData)
        {
            PlayerState playerState = _playersStates.Find((player) => player.OwnerClientId == playerInputData.PlayerId);
            playerState.UpdateInput(playerInputData);
        }

        public void AddPlayersState(PlayerState playerState)
        {
            _playersStates.Add(playerState);
        }

        private void RemovePlayerState(ulong id)
        {
            PlayerState playerNetworkInputState = _playersStates.Find((ps) => ps.OwnerClientId == id);
            _playersStates.Remove(playerNetworkInputState);
        }
    }
}