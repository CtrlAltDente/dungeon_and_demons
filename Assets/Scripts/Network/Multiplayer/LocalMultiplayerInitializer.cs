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
        public UnityEvent OnSuccessfullHostInitialization;
        public UnityEvent OnSuccessfullClientInitialization;

        public UnityEvent OnMultiplayerInitializationFailed;

        [SerializeField]
        private TextMeshProUGUI _ipAddressLabel;

        [SerializeField]
        private TMP_InputField _ipAddressField;

        private void Start()
        {
            _ipAddressField.text = GetLocalIpAddress();
        }

        public void InitializeHost()
        {
            if (StartHostWithUnityTransport(GetLocalIpAddress()))
            {
                _ipAddressLabel.text = $"Local IP Address: {GetLocalIpAddress()}";

                OnSuccessfullHostInitialization?.Invoke();
            }
            else
            {
                OnMultiplayerInitializationFailed?.Invoke();
            }
        }

        public void InitializeClient()
        {
            if (StartClientWithUnityTransport(_ipAddressField.text))
            {
                OnSuccessfullClientInitialization?.Invoke();
            }
            else
            {
                OnMultiplayerInitializationFailed?.Invoke();
            }
        }

        private bool StartHostWithUnityTransport(string ipAddress)
        {
            SetUnityTransportConnectionData(ipAddress);
            return NetworkManager.Singleton.StartHost();
        }

        private bool StartClientWithUnityTransport(string ipAddress)
        {
            SetUnityTransportConnectionData(ipAddress);
            return NetworkManager.Singleton.StartClient();
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