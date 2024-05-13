using Cinemachine;
using DungeonAndDemons.Player;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace DungeonAndDemons.Camera
{
    public class PlayerCameraSetter : MonoBehaviour
    {
        [SerializeField]
        private CinemachineVirtualCamera _cinemachineVirtualCamera;

        [SerializeField]
        private PlayerState _playerState;

        private void Start()
        {
            SetupCamera();
        }

        private void SetupCamera()
        {
            if (NetworkManager.Singleton)
            {
                SetupNetworkCamera();
            }
            else
            {
                SetupLocalCamera();
            }
        }

        public void SetPlayerTargetAndFollow(PlayerState playerState)
        {
            _cinemachineVirtualCamera.Follow = playerState.transform;
            _cinemachineVirtualCamera.LookAt = playerState.transform;
            transform.parent = null;
        }

        private void SetupNetworkCamera()
        {
            if (_playerState.OwnerClientId == NetworkManager.Singleton.LocalClientId)
            {
                SetPlayerTargetAndFollow(_playerState);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void SetupLocalCamera()
        {
            SetPlayerTargetAndFollow(_playerState);
        }
    }
}