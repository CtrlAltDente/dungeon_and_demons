using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace ClansWars.Network
{
    public class NetworkLobby : MonoBehaviour
    {
        public bool HasLobbyPlaces => _lobbyUsers.Find((user) => !user.IsConnected) != null;

        [SerializeField]
        private List<LobbyUser> _lobbyUsers = new List<LobbyUser>();

        private void Start()
        {
            SubscribeOnNetworkEvents();
            ResetClientsValues();
            ApproveClient(NetworkManager.Singleton.LocalClientId);
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
                NetworkManager.Singleton.OnClientConnectedCallback += ProcessConnectedClient;
                NetworkManager.Singleton.OnClientDisconnectCallback += ProcessDisconnectedClient;
            }
        }

        private void UnsubscribeFromNetworkEvents()
        {
            if (!NetworkManager.Singleton)
                return;

            if (NetworkManager.Singleton.IsHost)
            {
                NetworkManager.Singleton.OnClientConnectedCallback -= ProcessConnectedClient;
                NetworkManager.Singleton.OnClientDisconnectCallback -= ProcessDisconnectedClient;
            }
        }

        private void ProcessConnectedClient(ulong clientId)
        {
            if (NetworkManager.Singleton.IsHost)
            {
                if (HasLobbyPlaces)
                {
                    ApproveClient(clientId);
                }
                else
                {
                    DisconnectClient(clientId);
                }
            }
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
        }
    }
}
