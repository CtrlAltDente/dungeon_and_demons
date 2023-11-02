using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace ClansWars.Network
{
    public class NetworkManagerDuplicationChecker : MonoBehaviour
    {
        [SerializeField]
        private NetworkManager _networkManager;

        private void Awake()
        {
            CheckDuplication();
        }

        private void CheckDuplication()
        {
            if(NetworkManager.Singleton)
            {
                Destroy(_networkManager.gameObject);
            }
        }
    }
}