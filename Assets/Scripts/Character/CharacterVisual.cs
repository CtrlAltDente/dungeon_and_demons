using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Character
{
    [Serializable]
    public class CharacterVisual : MonoBehaviour
    {
        [SerializeField]
        private CharacterVisualConfig _characterVisualConfig;

        public CharacterVisualConfig CharacterVisualConfig
        {
            get
            {
                return _characterVisualConfig;
            }
            set
            {
                SetupCharacterVisual(value);
            }
        }

        private void SetupCharacterVisual(CharacterVisualConfig characterVisualConfig)
        {
            _characterVisualConfig = characterVisualConfig;
        }
    }
}