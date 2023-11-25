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
    public class LobbyStarter : MonoBehaviour
    {
        [Inject]
        private ScenesLoader _scenesLoader;

        public void GoToLobby()
        {
            _scenesLoader.FadeOut(() => OpenLobbyScene());
        }

        public void Shutdown()
        {
            NetworkManager.Singleton.Shutdown();
            _scenesLoader.LoadLocalScene("Scene_MainMenu");
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