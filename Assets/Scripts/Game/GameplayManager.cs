using DungeonAndDemons.Game;
using DungeonAndDemons.Input;
using DungeonAndDemons.Network;
using DungeonAndDemons.Player;
using DungeonAndDemons.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using Zenject;

public class GameplayManager : MonoBehaviour
{
    [SerializeField]
    private PlayerState _playerPrefab;

    [Inject]
    private MapsContainer _mapsContainer;
    [SerializeField]
    private Map _currentMap;

    private void Start()
    {
        InitializeMap();
        InitializePlayers();
    }

    public void InitializePlayer(ulong playerId, Vector3 position)
    {
        if(NetworkManager.Singleton.IsHost)
        {
            InitializeNetworkPlayer(playerId, position);
        }
        else if(!NetworkManager.Singleton.IsHost && !NetworkManager.Singleton.IsClient)
        {
            InitializeLocalPlayer();
        }
    }

    private void InitializeMap()
    {
        if (NetworkManager.Singleton.IsHost || !NetworkManager.Singleton.IsClient)
        {
            _currentMap = Instantiate(_mapsContainer.Maps[0], Vector3.zero, Quaternion.identity, null);
        }
    }

    private void InitializePlayers()
    {
        if (NetworkManager.Singleton.IsHost)
        {
            for (int i = 0; i < NetworkManager.Singleton.ConnectedClientsIds.Count; i++)
            {
                InitializePlayer((ulong)i, _currentMap.PlayerSpawnPositions[i].position);                
            }
        }

    }

    private void InitializeNetworkPlayer(ulong playerId, Vector3 position)
    {
        PlayerState newPlayer = Instantiate(_playerPrefab, position, Quaternion.identity, null);
        newPlayer.NetworkObject.SpawnAsPlayerObject(playerId);
    }

    private void InitializeLocalPlayer()
    {
        PlayerState newPlayer = Instantiate(_playerPrefab, Vector3.zero, Quaternion.identity, null);
    }
}
