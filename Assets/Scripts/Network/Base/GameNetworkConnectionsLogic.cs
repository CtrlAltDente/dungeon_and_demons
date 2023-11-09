using ClansWars.Game;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace ClansWars.Network
{
    public class GameNetworkConnectionsLogic : MonoBehaviour
    {
        [Inject]
        private ScenesLoader _scenesLoader;

        private void OnEnable()
        {
            SubscribeOnBasicEvents();
        }

        private void OnDisable()
        {
            UnsubscribeOnBasicEvents();
        }

        private void SubscribeOnBasicEvents()
        {
            if (NetworkManager.Singleton)
            {
                NetworkManager.Singleton.OnClientStopped += ReturnToMainScene;
            }
        }

        private void UnsubscribeOnBasicEvents()
        {
            if (NetworkManager.Singleton)
            {
                NetworkManager.Singleton.OnClientStopped -= ReturnToMainScene;
            }
        }

        private void ReturnToMainScene(bool value)
        {
            Destroy(NetworkManager.Singleton.gameObject);
            _scenesLoader.LoadLocalScene("Scene_MainMenu");
        }
    }
}