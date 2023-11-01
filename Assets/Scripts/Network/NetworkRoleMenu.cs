using ClansWars.Game;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace ClansWars.Network
{
    public class NetworkRoleMenu : MonoBehaviour
    {
        [Inject]
        private ScenesLoader _scenesLoader;

        public void InitializeHost()
        {
            NetworkManager.Singleton.StartHost();
            ChangeScene();
        }

        public void InitializeClient()
        {
            NetworkManager.Singleton.StartClient();
        }

        private void ChangeScene()
        {
            _scenesLoader.LoadNetworkScene("Scene_Lobby");
        }
    }
}