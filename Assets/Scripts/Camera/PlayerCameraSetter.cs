using Cinemachine;
using ClansWars.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClansWars.Camera
{
    public class PlayerCameraSetter : MonoBehaviour
    {
        [SerializeField]
        private CinemachineVirtualCamera _cinemachineVirtualCamera;

        [SerializeField]
        private PlayerState _playerState;

        public void SetPlayerTargetAndFollow(PlayerState playerState)
        {
            _cinemachineVirtualCamera.Follow = playerState.transform;
            _cinemachineVirtualCamera.LookAt = playerState.transform;
        }
    }
}