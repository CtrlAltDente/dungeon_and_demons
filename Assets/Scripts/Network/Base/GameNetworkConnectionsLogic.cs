using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClansWars.Network
{
    public class GameNetworkConnectionsLogic : MonoBehaviour
    {
        [SerializeField]
        private GameObject _networkManager;

        private void Awake()
        {
            CheckDuplicatedNetworkManager();
        }

        private void Start()
        {
            SubscribeOnBasicEvents();
        }

        private void CheckDuplicatedNetworkManager()
        {
            if (NetworkManager.Singleton != null)
            {
                Destroy(_networkManager);
            }
        }

        private void SubscribeOnBasicEvents()
        {
            if (NetworkManager.Singleton != null)
            {
                NetworkManager.Singleton.OnServerStopped += ReturnToMainScene;
                NetworkManager.Singleton.OnClientStopped += ReturnToMainScene;
            }
        }

        private void UnsubscribeOnBasicEvents()
        {
            if (NetworkManager.Singleton != null)
            {
                NetworkManager.Singleton.OnServerStopped -= ReturnToMainScene;
                NetworkManager.Singleton.OnClientStopped -= ReturnToMainScene;
            }
        }

        private void ReturnToMainScene(bool value)
        {
            UnsubscribeOnBasicEvents();
            SceneManager.LoadScene("Scene_MainMenu");
        }
    }
}