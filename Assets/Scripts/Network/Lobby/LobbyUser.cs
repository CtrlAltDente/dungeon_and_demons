using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

namespace ClansWars.Network
{
    public class LobbyUser : NetworkBehaviour
    {
        [SerializeField]
        private NetworkVariable<ulong> _clientId;

        private const ulong NO_CLIENT_ID = 99;

        [SerializeField]
        private Image _userReadyImage;

        public bool IsConnected
        {
            get
            {
                return _clientId.Value != NO_CLIENT_ID;
            }
        }

        public ulong ClientId
        {
            set
            {
                _clientId.Value = value;
            }
            get
            {
                return _clientId.Value;
            }
        }

        private void Start()
        {
            _clientId.OnValueChanged += UpdateClientImage;
            UpdateClientImage();
        }

        public void ClearClient()
        {
            _clientId.Value = NO_CLIENT_ID;
        }

        private void UpdateClientImage(ulong previous = 0, ulong current = 0)
        {
            _userReadyImage.color = IsConnected ? Color.green : Color.red;
        }
    }
}