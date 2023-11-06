using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

namespace ClansWars.Game
{
    public class ScenesLoader : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _canvasGroup;
        [SerializeField]
        private Image _image;

        private const float _fadeSpeed = 1f;

        private void Start()
        {
            FadeIn();
        }

        public void LoadNetworkScene(string sceneName)
        {
            FadeOut(() => NetworkManager.Singleton.SceneManager.LoadScene(sceneName, LoadSceneMode.Single));
        }

        public void LoadLocalScene(string sceneName)
        {
            FadeOut(() => SceneManager.LoadScene(sceneName));
        }

        public void FadeIn(TweenCallback OnEndAction = null)
        {
            _image.raycastTarget = false;
            _canvasGroup.DOFade(0, _fadeSpeed).OnComplete(OnEndAction);
        }

        public void FadeOut(TweenCallback OnEndAction = null)
        {
            _image.raycastTarget = true;
            _canvasGroup.DOFade(1, _fadeSpeed).OnComplete(OnEndAction);
        }
    }
}