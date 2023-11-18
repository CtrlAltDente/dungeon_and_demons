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

    [SerializeField]
    private PlayersInput _playersInput;

    private void Start()
    {
        InitializeMap();
        InitializePlayers();
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
                InitializeNetworkPlayer(NetworkManager.Singleton.ConnectedClientsIds[i], _currentMap.PlayerSpawnPositions[i].position);
            }
        }
        else if (!NetworkManager.Singleton.IsHost && !NetworkManager.Singleton.IsClient)
        {
            InitializeLocalPlayer();
        }
    }

    private void InitializeNetworkPlayer(ulong playerId, Vector3 position)
    {
        PlayerState newPlayer = Instantiate(_playerPrefab, position, Quaternion.identity, null);
        newPlayer.NetworkObject.SpawnWithOwnership(playerId);
        newPlayer.SetCharacterClientRpc(0);
        _playersInput.AddPlayersState(newPlayer);
    }

    private void InitializeLocalPlayer()
    {
        PlayerState newPlayer = Instantiate(_playerPrefab, Vector3.zero, Quaternion.identity, null);
        _playersInput.AddPlayersState(newPlayer);
    }
}
