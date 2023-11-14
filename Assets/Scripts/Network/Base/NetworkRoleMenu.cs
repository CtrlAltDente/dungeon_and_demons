using DungeonAndDemons.Game;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace DungeonAndDemons.Network
{
    public class NetworkRoleMenu : MonoBehaviour
    {
        [Inject]
        private ScenesLoader _scenesLoader;

        public void InitializeHost()
        {
            StartCoroutine(TryInitializeHostAndCreateLobby());
        }

        public void InitializeClient()
        {
            StartCoroutine(TryInitializeClientAndConnect());
        }

        private IEnumerator TryInitializeHostAndCreateLobby()
        {
            _scenesLoader.FadeOut(() => NetworkManager.Singleton.StartHost());

            yield return new WaitForSeconds(1f);

            if (NetworkManager.Singleton.IsConnectedClient)
            {
                _scenesLoader.LoadNetworkScene("Scene_Lobby");
            }
            else
            {
                ShutdownAndReturnToMainMenu();
            }
        }

        private IEnumerator TryInitializeClientAndConnect()
        {
            _scenesLoader.FadeOut(() => NetworkManager.Singleton.StartClient());

            yield return new WaitForSeconds(3f);

            if (!NetworkManager.Singleton.IsConnectedClient)
            {
                ShutdownAndReturnToMainMenu();
            }
        }

        private void ShutdownAndReturnToMainMenu()
        {
            NetworkManager.Singleton.Shutdown();
            _scenesLoader.LoadLocalScene("Scene_MainMenu");
        }
    }
}