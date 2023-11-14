using DungeonAndDemons.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonAndDemons.Input
{
    public class PlayerInput : MonoBehaviour
    {
        public UnityEvent<PlayerInputData> OnPlayerInputDataReady;

        public UnityEvent<PlayerInputData> OnFixedPlayerInputDataReady;
        
        [SerializeField]
        public Animator _animator;

        public void SetPlayerInputData(PlayerInputData playerInputData)
        {
            OnPlayerInputDataReady?.Invoke(playerInputData);
            playerInputData = FixInputDependsOnAnimator(playerInputData);
            OnFixedPlayerInputDataReady?.Invoke(playerInputData);
        }

        public void SetCharacterAnimator(PlayerCharacter playerCharacter)
        {
            _animator = playerCharacter.Animator;
        }

        private PlayerInputData FixInputDependsOnAnimator(PlayerInputData playerInputData)
        {
            playerInputData.MovementVector = _animator.GetBool("InMovement") ? playerInputData.MovementVector : Vector2.zero;
            playerInputData.IsRoll = _animator.GetBool("InRoll");

            return playerInputData;
        }
    }
}