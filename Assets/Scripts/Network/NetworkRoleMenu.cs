using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClansWars.Network
{
    public class NetworkRoleMenu : MonoBehaviour
    {
        public void InitializeHost()
        {
            NetworkManager.Singleton.StartHost();
            SceneManager.LoadScene("GameScene");
        }

        public void InitializeClient()
        {
            NetworkManager.Singleton.StartClient();
        }
    }
}