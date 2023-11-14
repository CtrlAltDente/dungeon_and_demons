using DungeonAndDemons.Input;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace DungeonAndDemons.Player
{
    public class PlayerState : NetworkBehaviour
    {
        public bool IsAlive = true;

        [SerializeField]
        private PlayerCharacter[] _characters;

        [SerializeField]
        private PlayerInput _playerInput;
        [SerializeField]
        private PlayerAnimatorLogic _playerAnimatorLogic;

        public void UpdateInput(PlayerInputData playerInputData)
        {
            if (IsAlive)
            {
                _playerInput.SetPlayerInputData(playerInputData);
            }
        }

        [ClientRpc]
        public void SetCharacterClientRpc(int characterIndex)
        {
            PlayerCharacter currentCharacter = _characters[characterIndex];

            foreach (PlayerCharacter character in _characters)
            {
                if (character != currentCharacter)
                {
                    character.gameObject.SetActive(false);
                }
            }

            _playerInput.SetCharacterAnimator(currentCharacter);
            _playerAnimatorLogic.SetCharacterAnimator(currentCharacter);
        }
    }
}