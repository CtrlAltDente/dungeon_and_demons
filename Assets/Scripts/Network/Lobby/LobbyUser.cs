using DungeonAndDemons.Game;
using DungeonAndDemons.UI;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

namespace DungeonAndDemons.Network
{
    public class LobbyUser : NetworkBehaviour
    {
        [SerializeField]
        private NetworkVariable<ulong> _clientId;
        [SerializeField]
        private NetworkVariable<int> _clientCharacter;

        private const ulong NO_CLIENT_ID = 99;

        [SerializeField]
        private Image _userReadyImage;
        [SerializeField]
        private Image _userCharacterImage;

        [SerializeField]
        private Selection[] _selections;

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
            _clientCharacter.OnValueChanged += UpdateClientCharacterImage;

            UpdateClientImage();
            UpdateClientCharacterImage();
            
            SetUserCharacterServerRpc(_clientCharacter.Value);
        }

        public void ClearClient()
        {
            _clientId.Value = NO_CLIENT_ID;
            _clientCharacter.Value = 0;
            SetUserCharacterServerRpc(_clientCharacter.Value);
        }

        public void ChooseNext()
        {
            SetUserCharacterServerRpc(_clientCharacter.Value + 1);
        }

        public void ChoosePrevious()
        {
            SetUserCharacterServerRpc(_clientCharacter.Value - 1);
        }

        private void UpdateClientImage(ulong previous = 0, ulong current = 0)
        {
            _userReadyImage.color = IsConnected ? Color.green : Color.red;
        }

        private void UpdateClientCharacterImage(int previous = 0, int current = 0)
        {
            _userCharacterImage.sprite = _selections[current].Sprite;
        }

        [ServerRpc(RequireOwnership = false)]
        private void SetUserCharacterServerRpc(int value)
        {
            _clientCharacter.Value = Mathf.Clamp(value, 0, _selections.Length - 1);
        }
    }
}