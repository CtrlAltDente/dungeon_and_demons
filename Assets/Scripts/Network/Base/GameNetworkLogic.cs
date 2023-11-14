using DungeonAndDemons.Game;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace DungeonAndDemons.Network
{
    public class GameNetworkLogic : MonoBehaviour
    {
        [Inject]
        private ScenesLoader _scenesLoader;

        [SerializeField]
        private List<string> _clientsPings;

        private void OnEnable()
        {
            SubscribeOnBasicEvents();
        }

        private void OnDisable()
        {
            UnsubscribeOnBasicEvents();
        }

        private void Start()
        {
            if (NetworkManager.Singleton.IsHost)
            {
                StartCoroutine(ShowPing());
            }
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