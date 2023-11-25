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
        public UnityEvent OnSuccessfullMultiplayerInitialization;

        [SerializeField]
        private TextMeshProUGUI _gameJoinCodeLabel;

        [SerializeField]
        private TMP_InputField _gameJoinCodeField;

        public async void InitializeHost()
        {
            string joinGameCode = await StartHostWithRelay();
            _gameJoinCodeLabel.text = $"Game join code: {joinGameCode}";

            OnSuccessfullMultiplayerInitialization?.Invoke();
        }

        public async void InitializeClient()
        {
            await StartClientWithRelay(_gameJoinCodeField.text);
            
            OnSuccessfullMultiplayerInitialization?.Invoke();
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