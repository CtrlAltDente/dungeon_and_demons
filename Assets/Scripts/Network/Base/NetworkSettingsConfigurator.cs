using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

namespace ClansWars.Network
{
    public class NetworkSettingsConfigurator : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField _ipAddressLabel;

        public void SetLocalIpAddressToNetworkManager()
        {
            SetTargetIp(GetLocalIpAddress());
        }

        public void SetEnteredIpAddressToNetworkManager()
        {
            SetTargetIp(_ipAddressLabel.text);
        }

        public void SetTargetIp(string ipAddress)
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