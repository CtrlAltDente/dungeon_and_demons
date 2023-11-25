using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

namespace DungeonAndDemons.UI
{
    public class SelectionsMenu : MonoBehaviour
    {
        public Selection ActiveSelection { get; private set; }

        [SerializeField]
        private Image _activeSelectionImage;

        [SerializeField]
        private Selection[] _selections;

        private int _activeSelectionIndex = 0;

        public void ChooseNext()
        {
            Choose(_activeSelectionIndex + 1);
        }

        public void ChoosePrevious()
        {
            Choose(_activeSelectionIndex - 1);
        }

        private void Choose(int value)
        {
            _activeSelectionIndex = Mathf.Clamp(value, 0, _selections.Length - 1);
            ActiveSelection = _selections[_activeSelectionIndex];
            _activeSelectionImage.sprite = ActiveSelection.Sprite;
        }
    }
}