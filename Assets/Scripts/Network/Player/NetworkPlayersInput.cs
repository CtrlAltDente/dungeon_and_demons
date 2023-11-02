using ClansWars.Input;
using ClansWars.Player;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace ClansWars.Network
{
    public class NetworkPlayersInput : MonoBehaviour
    {
        [SerializeField]
        private List<PlayerState> _playersStates = new List<PlayerState>();

        private void Start()
        {
            if (NetworkManager.Singleton.IsHost || NetworkManager.Singleton.IsServer)
            {
                NetworkManager.Singleton.OnClientDisconnectCallback += RemoveInputOfPlayer;
            }
        }

        private void Update()
        {
            if (NetworkManager.Singleton.IsHost || NetworkManager.Singleton.IsServer)
            {
                SetInputToPlayer();
            }
        }

        public void AddPlayersInputStates(PlayerState playerState)
        {
            _playersStates.Add(playerState);
        }

        public void SetInputToPlayer()
        {
            foreach (PlayerState playerState in _playersStates)
            {
                playerState.UpdateInput(playerState.PlayerInputData.Value);
            }
        }

        private void RemoveInputOfPlayer(ulong id)
        {
            PlayerState playerNetworkInputState = _playersStates.Find((ps) => ps.PlayerId.Value == id);
            _playersStates.Remove(playerNetworkInputState);
        }
    }
}