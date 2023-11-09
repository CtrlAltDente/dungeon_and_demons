using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClansWars.UI
{
    public class Menu : MonoBehaviour
    {
        public Menu PreviousMenu;
        
        [SerializeField]
        private CanvasGroup _canvasGroup;
        
        public void SetPosition(Vector2 position, bool instantly,TweenCallback OnEndAction = null)
        {
            if(instantly)
            {
                GetComponent<RectTransform>().SetLocalPositionAndRotation(position, Quaternion.identity);
                OnEndAction?.Invoke();
            }
            else
            {
                _canvasGroup.interactable = false;
                OnEndAction += () => _canvasGroup.interactable = true;
                GetComponent<RectTransform>().DOLocalMove(position, 0.5f).OnComplete(OnEndAction);
            }
        }
    }
}