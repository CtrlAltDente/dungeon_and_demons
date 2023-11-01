using ClansWars.Camera;
using ClansWars.Input;
using ClansWars.Player;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;


namespace ClansWars.Network
{
    public class NetworkPlayerInitializer : MonoBehaviour
    {
        [SerializeField]
        private NetworkPlayersInput _networkPlayersInput;

        [SerializeField]
        private PlayerState _playerPrefab;

        private void Start()
        {
            if(NetworkManager.Singleton.IsHost)
            {
                NetworkManager.Singleton.OnClientConnectedCallback += InitializePlayer;
                InitializePlayer(NetworkManager.Singleton.LocalClientId);
            }
        }

        private void OnDisable()
        {
            if (NetworkManager.Singleton.IsHost)
            {
                NetworkManager.Singleton.OnClientConnectedCallback -= InitializePlayer;
            }
        }

        private void InitializePlayer(ulong playerId)
        {
            Debug.Log("Client connected");
            PlayerState _newPlayer = Instantiate(_playerPrefab, Vector3.zero, Quaternion.identity, null);
            _newPlayer.NetworkObject.SpawnWithOwnership(playerId);
            _newPlayer.PlayerId.Value = playerId;
            _networkPlayersInput.AddPlayersInputStates(_newPlayer);
        }
    }
}