using ClansWars.Input;
using ClansWars.Player;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace ClansWars.Network
{
    public class NetworkPlayersInput : NetworkBehaviour
    {
        [SerializeField]
        private List<PlayerState> _playersStates = new List<PlayerState>();

        private void Awake()
        {
            DestroyAtLocalMode();
        }

        private void Start()
        {
            if (NetworkManager.Singleton.IsHost)
            {
                NetworkManager.Singleton.OnClientDisconnectCallback += RemoveInputOfPlayer;
            }
        }

        [ServerRpc(RequireOwnership = false)]
        public void SetInputToPlayerServerRpc(PlayerInputData playerInputData)
        {
            Debug.Log(playerInputData.PlayerId);
            PlayerState playerState = _playersStates.Find((player) => player.OwnerClientId == playerInputData.PlayerId);
            playerState.UpdateInput(playerInputData);
        }

        public void AddPlayersInputStates(PlayerState playerState)
        {
            _playersStates.Add(playerState);
        }

        private void DestroyAtLocalMode()
        {
            if(!NetworkManager.Singleton.IsClient)
            {
                Destroy(gameObject);
            }
        }

        private void RemoveInputOfPlayer(ulong id)
        {
            PlayerState playerNetworkInputState = _playersStates.Find((ps) => ps.OwnerClientId == id);
            _playersStates.Remove(playerNetworkInputState);
        }
    }
}