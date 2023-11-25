using DungeonAndDemons.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonAndDemons.Network
{
    public class LocalMultiplayerInitializer : MonoBehaviour, IMultiplayerInitalizer
    {
        public UnityEvent OnSuccessfullMultiplayerInitialization;

        [SerializeField]
        private TextMeshProUGUI _ipAddressLabel;

        [SerializeField]
        private TMP_InputField _ipAddressField;

        public void InitializeHost()
        {
            StartHostWithUnityTransport(GetLocalIpAddress());
            _ipAddressLabel.text = $"Local IP Address: {GetLocalIpAddress()}";

            OnSuccessfullMultiplayerInitialization?.Invoke();
        }

        public void InitializeClient()
        {
            StartClientWithUnityTransport(_ipAddressField.text);

            OnSuccessfullMultiplayerInitialization?.Invoke();
        }

        private void StartHostWithUnityTransport(string ipAddress)
        {
            SetUnityTransportConnectionData(ipAddress);
            NetworkManager.Singleton.StartHost();
        }

        private void StartClientWithUnityTransport(string ipAddress)
        {
            SetUnityTransportConnectionData(ipAddress);
            NetworkManager.Singleton.StartClient();
        }

        private void SetUnityTransportConnectionData(string ipAddress)
        {
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(ipAddress, 7777);
        }

        private string GetLocalIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            return null;
        }
    }
}