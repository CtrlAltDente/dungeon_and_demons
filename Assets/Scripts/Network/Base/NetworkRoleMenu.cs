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
            _scenesLoader.LoadNetworkScene("Scene_Lobby");
        }

        public void InitializeClient()
        {
            StartCoroutine(TryInitializeClientAndConnect());
        }

        private IEnumerator TryInitializeClientAndConnect()
        {
            _scenesLoader.FadeOut(() => NetworkManager.Singleton.StartClient());

            yield return new WaitForSeconds(3f);

            if(!NetworkManager.Singleton.IsConnectedClient)
            {
                NetworkManager.Singleton.Shutdown();
                _scenesLoader.LoadLocalScene("Scene_MainMenu");
            }
        }
    }
}