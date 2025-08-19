using DungeonAndDemons.Interfaces;
using DungeonAndDemons.Network;
using DungeonAndDemons.Player;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DungeonAndDemons.Input
{
    public class UserInputForPlayer : MonoBehaviour
    {
        [SerializeField]
        private PlayerState _playerState;

        [SerializeField]
        private KeyboardInputType _keyboardInputTypePrefab;

        private IInputType _currentInputType;

        private int _inputUpdatePerSecond = 25;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.1f);
            InitializeInput();

            StartCoroutine(UpdateInputForPlayer());
        }

        /*private void Update()
        {
            if (NetworkManager.Singleton)
            {
                SetNetworkInput();
            }
            else
            {
                SetLocalInput();
            }
        }*/

        private void InitializeInput()
        {
            if (NetworkManager.Singleton)
            {
                if (_playerState.IsOwner || !NetworkManager.Singleton.IsClient)
                {
                    _currentInputType = Instantiate(_keyboardInputTypePrefab, transform);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
            else
            {
                _currentInputType = Instantiate(_keyboardInputTypePrefab, transform);
            }
        }

        private IEnumerator UpdateInputForPlayer()
        {
            while (gameObject.activeInHierarchy)
            {
                yield return new WaitForSeconds(1f / _inputUpdatePerSecond);

                if(NetworkManager.Singleton)
                {
                    SetNetworkInput();
                }
                else
                {
                    SetLocalInput();
                }
            }
        }

        private void SetNetworkInput()
        {
            if (_playerState.IsAlive)
            {
                _playerState.SetInputServerRpc(_currentInputType.GetPlayerInputData());
                Debug.Log($"Send data input network");
            }
            else
            {
                _playerState.SetInputServerRpc(new PlayerInputData(NetworkManager.Singleton.LocalClientId, default, default, default, default, default, default));
            }
        }
        private void SetLocalInput()
        {
            if (_playerState.IsAlive)
            {
                _playerState.SetInput(_currentInputType.GetPlayerInputData());
                Debug.Log($"Send data input local");
            }
            else
            {
                _playerState.SetInput(new PlayerInputData(NetworkManager.Singleton.LocalClientId, default, default, default, default, default, default));
            }
        }
    }
}
