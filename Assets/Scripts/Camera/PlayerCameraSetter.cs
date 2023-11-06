using Cinemachine;
using ClansWars.Player;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace ClansWars.Camera
{
    public class PlayerCameraSetter : MonoBehaviour
    {
        [SerializeField]
        private CinemachineVirtualCamera _cinemachineVirtualCamera;

        [SerializeField]
        private PlayerState _playerState;

        private void Start()
        {
            CheckOwnPlayer();
        }

        private void CheckOwnPlayer()
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

        public void SetPlayerTargetAndFollow(PlayerState playerState)
        {
            _cinemachineVirtualCamera.Follow = playerState.transform;
            _cinemachineVirtualCamera.LookAt = playerState.transform;
            transform.parent = null;
        }
    }
}