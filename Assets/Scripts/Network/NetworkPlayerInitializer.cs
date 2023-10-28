using ClansWars.Camera;
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
            _newPlayer.NetworkObject.Spawn();
            //_newPlayer.SetId(playerId);
        }
    }
}