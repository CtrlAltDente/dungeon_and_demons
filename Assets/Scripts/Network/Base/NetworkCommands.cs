using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace DungeonAndDemons.Network
{
    public class NetworkCommands : MonoBehaviour
    {
        public void StopNetworkAndExitToMainMenu()
        {
            NetworkManager.Singleton.Shutdown();
            Destroy(NetworkManager.Singleton.gameObject);
        }
    }
}