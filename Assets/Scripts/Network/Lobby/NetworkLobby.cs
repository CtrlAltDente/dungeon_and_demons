using DungeonAndDemons.Game;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DungeonAndDemons.Network
{
    public class NetworkLobby : NetworkBehaviour
    {
        public bool HasLobbyPlaces => NetworkManager.Singleton.ConnectedClientsList.Count < _maxPlayersInLobby;

        [Inject]
        private ScenesLoader _scenesLoader;

        [SerializeField]
        private int _maxPlayersInLobby = 4;

        private void OnEnable()
        {
            if(NetworkManager.Singleton.IsHost)
            {
                NetworkManager.Singleton.ConnectionApprovalCallback += ApproveConnections;
            }
        }

        private void OnDisable()
        {
            if(NetworkManager.Singleton.IsHost)
            {
                NetworkManager.Singleton.ConnectionApprovalCallback -= ApproveConnections;
            }
        }

        [ClientRpc]
        public void StartLobbyGameClientRpc()
        {
            if (NetworkManager.Singleton.IsHost)
            {
                _scenesLoader.LoadNetworkScene("Scene_Game");
            }
            else if (NetworkManager.Singleton.IsClient)
            {
                _scenesLoader.FadeOut();
            }
        }

        private void ApproveConnections(NetworkManager.ConnectionApprovalRequest request, NetworkManager.ConnectionApprovalResponse response)
        {
            response.Approved = HasLobbyPlaces;
        }
    }
}
