using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClansWars.Network
{
    public class NetworkRoleMenu : MonoBehaviour
    {
        private void Start()
        {
        }

        private void OnDestroy()
        {
            
        }

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
            NetworkManager.Singleton.SceneManager.LoadScene("LobbyScene", LoadSceneMode.Single);
        }
    }
}