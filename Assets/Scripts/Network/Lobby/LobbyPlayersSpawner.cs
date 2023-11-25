using DungeonAndDemons.Game;
using DungeonAndDemons.UI;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

namespace DungeonAndDemons.Network
{
    public class LobbyPlayersSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameplayManager _gameplayManager;

        private void OnEnable()
        {
            if(NetworkManager.Singleton.IsHost)
            {
                NetworkManager.Singleton.OnClientConnectedCallback += SpawnPlayerOnConnection;
            }
        }

        private void OnDisable()
        {
            if (NetworkManager.Singleton.IsHost)
            {
                NetworkManager.Singleton.OnClientConnectedCallback -= SpawnPlayerOnConnection;
            }
        }

        private void SpawnPlayerOnConnection(ulong playerId)
        {
            _gameplayManager.InitializePlayer(playerId, Vector3.zero);
        }
    }
}