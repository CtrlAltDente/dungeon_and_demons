using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

namespace ClansWars.Game
{
    public class ScenesLoader : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _canvasGroup;

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
            _canvasGroup.DOFade(0, _fadeSpeed).OnComplete(OnEndAction);
        }

        public void FadeOut(TweenCallback OnEndAction = null)
        {
            _canvasGroup.DOFade(1, _fadeSpeed).OnComplete(OnEndAction);
        }
    }
}