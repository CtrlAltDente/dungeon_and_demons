using DungeonAndDemons.Player;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace DungeonAndDemons.Game
{
    public class Map : NetworkBehaviour
    {
        public Transform[] PlayerSpawnPositions;
        public Transform[] EnemySpawnPositions;

        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            if(NetworkManager.Singleton.IsHost)
            {
                GetComponent<NetworkObject>().Spawn();
            }
        }
    }
}