using System.Threading.Tasks;
using TMPro;
using Unity.Netcode.Transports.UTP;
using Unity.Netcode;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using Unity.Services.Authentication;
using Unity.Networking.Transport.Relay;
using DungeonAndDemons.Interfaces;
using UnityEngine.Events;

namespace DungeonAndDemons.Network
{
    public class OnlineMultiplayerInitializer : MonoBehaviour, IMultiplayerInitalizer
    {
        public UnityEvent OnSuccessfullHostInitialization;
        public UnityEvent OnSuccessfullClientInitialization;

        public UnityEvent OnMultiplayerInitializationFailed;

        [SerializeField]
        private TextMeshProUGUI _gameJoinCodeLabel;

        [SerializeField]
        private TMP_InputField _gameJoinCodeField;

        public async void InitializeHost()
        {
            string joinGameCode = await StartHostWithRelay();

            if (joinGameCode != null)
            {
                _gameJoinCodeLabel.text = $"Game join code: {joinGameCode}";
                OnSuccessfullHostInitialization?.Invoke();
            }
            else
            {
                OnMultiplayerInitializationFailed?.Invoke();
            }

        }

        public async void InitializeClient()
        {
            if (await StartClientWithRelay(_gameJoinCodeField.text))
            {
                OnSuccessfullClientInitialization?.Invoke();
            }
            else
            {
                OnMultiplayerInitializationFailed?.Invoke();
            }
        }

        private async Task<string> StartHostWithRelay(int maxConnections = 5)
        {
            await UnityServices.InitializeAsync();

            if (!AuthenticationService.Instance.IsSignedIn)
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
            }

            Allocation allocation = await RelayService.Instance.CreateAllocationAsync(maxConnections);
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(new RelayServerData(allocation, "dtls"));
            var joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);
            return NetworkManager.Singleton.StartHost() ? joinCode : null;
        }

        private async Task<bool> StartClientWithRelay(string joinCode)
        {
            await UnityServices.InitializeAsync();

            if (!AuthenticationService.Instance.IsSignedIn)
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
            }

            var joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode: joinCode);
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(new RelayServerData(joinAllocation, "dtls"));
            return !string.IsNullOrEmpty(joinCode) && NetworkManager.Singleton.StartClient();
        }
    }
}