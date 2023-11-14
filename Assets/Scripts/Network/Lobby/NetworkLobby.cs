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
        public bool HasLobbyPlaces => _lobbyUsers.Find((user) => !user.IsConnected) != null;

        [Inject]
        private ScenesLoader _scenesLoader;

        [SerializeField]
        private List<LobbyUser> _lobbyUsers = new List<LobbyUser>();

        [SerializeField]
        private Button _startLobbyButton;

        private void Start()
        {
            SubscribeOnNetworkEvents();
            ResetClientsValues();
            ProcessAlreadyConnectedClients();
        }

        private void OnDestroy()
        {
            UnsubscribeFromNetworkEvents();
        }

        private void SubscribeOnNetworkEvents()
        {
            if (!NetworkManager.Singleton)
                return;

            if (NetworkManager.Singleton.IsHost)
            {
                NetworkManager.Singleton.ConnectionApprovalCallback += ConnectionApproval;
                NetworkManager.Singleton.OnClientConnectedCallback += ProcessConnectedClient;
                NetworkManager.Singleton.OnClientDisconnectCallback += ProcessDisconnectedClient;
                _startLobbyButton.onClick.AddListener(StartLobbyGameClientRpc);
            }
        }

        private void UnsubscribeFromNetworkEvents()
        {
            if (!NetworkManager.Singleton)
                return;

            if (NetworkManager.Singleton.IsHost)
            {
                NetworkManager.Singleton.ConnectionApprovalCallback -= ConnectionApproval;
                NetworkManager.Singleton.OnClientConnectedCallback -= ProcessConnectedClient;
                NetworkManager.Singleton.OnClientDisconnectCallback -= ProcessDisconnectedClient;
                _startLobbyButton.onClick.RemoveListener(StartLobbyGameClientRpc);
            }
        }

        private void ProcessAlreadyConnectedClients()
        {
            if (!NetworkManager.Singleton)
                return;

            if (NetworkManager.Singleton.IsHost)
            {
                foreach (ulong id in NetworkManager.Singleton.ConnectedClientsIds)
                {
                    ProcessConnectedClient(id);
                }
            }
        }

        private void ConnectionApproval(NetworkManager.ConnectionApprovalRequest connectionApprovalRequest, NetworkManager.ConnectionApprovalResponse connectionApprovalResponse)
        {
            if (NetworkManager.Singleton.IsHost)
            {
                if (HasLobbyPlaces)
                {
                    connectionApprovalResponse.Approved = true;
                }
                else
                {
                    connectionApprovalResponse.Approved = false;
                }
            }
        }

        private void ProcessConnectedClient(ulong clientId)
        {
            ApproveClient(clientId);
        }

        private void ProcessDisconnectedClient(ulong clientId)
        {
            if (NetworkManager.Singleton.IsHost)
            {
                LobbyUser lobbyUser = _lobbyUsers.Find((user) => user.ClientId == clientId);

                if (lobbyUser)
                {
                    lobbyUser.ClearClient();
                }
            }
        }

        private void ApproveClient(ulong clientId)
        {
            if (NetworkManager.Singleton.IsHost)
            {
                foreach (LobbyUser lobbyUser in _lobbyUsers)
                {
                    if (!lobbyUser.IsConnected)
                    {
                        lobbyUser.ClientId = clientId;
                        break;
                    }
                }
            }
        }

        private void DisconnectClient(ulong clientId)
        {
            if (NetworkManager.Singleton.IsHost)
            {
                NetworkManager.Singleton.DisconnectClient(clientId);
            }
        }

        private void ResetClientsValues()
        {
            if (NetworkManager.Singleton.IsHost)
            {
                foreach (LobbyUser lobbyUser in _lobbyUsers)
                {
                    lobbyUser.ClearClient();
                }
            }
            else
            {
                _startLobbyButton.gameObject.SetActive(false);
            }
        }

        [ClientRpc]
        private void StartLobbyGameClientRpc()
        {
            _startLobbyButton.onClick.RemoveAllListeners();

            if (NetworkManager.Singleton.IsHost)
            {
                _scenesLoader.LoadNetworkScene("Scene_Game");
            }
            else if (NetworkManager.Singleton.IsClient)
            {
                _scenesLoader.FadeOut();
            }
        }
    }
}
