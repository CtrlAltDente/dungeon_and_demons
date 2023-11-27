using DungeonAndDemons.Characters;
using DungeonAndDemons.Input;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonAndDemons.Player
{
    public class PlayerState : NetworkBehaviour
    {
        public NetworkVariable<PlayerInputData> PlayerInputData = new NetworkVariable<PlayerInputData>(default, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

        public bool IsAlive = true;
        public CharacterCharacteristics CharacterCharacteristics;

        public UnityEvent<Animator> OnAnimatorGetted;

        [SerializeField]
        private PlayerCharacter[] _characters;
        [SerializeField]
        private PlayerCharacter _currentCharacter;

        [SerializeField]
        private PlayerInput _playerInput;
        [SerializeField]
        private PlayerAnimatorLogic _playerAnimatorLogic;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(5f);
            OnAnimatorGetted?.Invoke(_currentCharacter.Animator);
        }

        private void Update()
        {
            ApplyInput();
        }

        public void SetInput(PlayerInputData playerInputData)
        {
            PlayerInputData.Value = playerInputData;
        }

        [ClientRpc]
        public void SetCharacterClientRpc(CharacterClass characterClass)
        {
            PlayerCharacter currentCharacter = _characters.First(playerCharacter => playerCharacter.CharacterClass == CharacterClass.Warrior);

            foreach (PlayerCharacter character in _characters)
            {
                if (character != currentCharacter)
                {
                    character.gameObject.SetActive(false);
                }
            }

            _currentCharacter = currentCharacter;
        }

        public void ApplyInput()
        {
            if(IsHost)
            {
                _playerInput.SetPlayerInputData(PlayerInputData.Value);
            }
        }
    }
}