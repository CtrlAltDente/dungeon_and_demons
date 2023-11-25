using DungeonAndDemons.Game;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Zenject;

namespace DungeonAndDemons.Network
{
    public class NetworkStatus : MonoBehaviour
    {
        public UnityEvent OnNetworkStop;

        [Inject]
        private ScenesLoader _scenesLoader;

        [SerializeField]
        private List<string> _clientsPings;

        public void Shutdown()
        {
            if (NetworkManager.Singleton.IsClient)
            {
                NetworkManager.Singleton.Shutdown();
            }
            else
            {
                RaiseOnNetworkStopEvents(false);
            }
        }

        private void Start()
        {
            SubscribeOnBasicEvents();

            if (NetworkManager.Singleton.IsHost)
            {
                StartCoroutine(ShowPing());
            }
        }

        private void OnDestroy()
        {
            UnsubscribeOnBasicEvents();
        }

        private void SubscribeOnBasicEvents()
        {
            if (NetworkManager.Singleton)
            {
                NetworkManager.Singleton.OnClientStopped += RaiseOnNetworkStopEvents;
            }
        }

        private void UnsubscribeOnBasicEvents()
        {
            if (NetworkManager.Singleton)
            {
                NetworkManager.Singleton.OnClientStopped -= RaiseOnNetworkStopEvents;
            }
        }

        private void RaiseOnNetworkStopEvents(bool value)
        {
            OnNetworkStop?.Invoke();
        }

        private IEnumerator ShowPing()
        {
            while (true)
            {
                yield return new WaitForSeconds(2f);

                _clientsPings.Clear();

                foreach (ulong clientId in NetworkManager.Singleton.ConnectedClientsIds)
                {
                    _clientsPings.Add($"ID({clientId}), Ping({NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetCurrentRtt(clientId)})");
                }
            }
        }
    }
}