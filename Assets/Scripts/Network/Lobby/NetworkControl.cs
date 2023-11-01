using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace ClansWars.Network
{
    public class NetworkControl : MonoBehaviour
    {
        public void StopNetworkAndExitToMainMenu()
        {
            NetworkManager.Singleton.Shutdown();
        }
    }
}