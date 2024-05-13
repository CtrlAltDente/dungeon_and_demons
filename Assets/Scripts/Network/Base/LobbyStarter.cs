using DungeonAndDemons.Game;
using DungeonAndDemons.Interfaces;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace DungeonAndDemons.Network
{
    public class LobbyStarter : NetworkBehaviour
    {
        [Inject]
        private ScenesLoader _scenesLoader;

        [ClientRpc]
        public void GoToLobbyClientRpc()
        {
            _scenesLoader.FadeOut(() => OpenLobbyScene());
        }

        private void OpenLobbyScene()
        {
            if(NetworkManager.Singleton.IsHost)
            {
                _scenesLoader.LoadNetworkScene("Scene_Lobby");
            }
        }
    }
}