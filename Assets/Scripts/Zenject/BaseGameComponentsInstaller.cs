using ClansWars.Game;
using ClansWars.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ClansWars.Zenject
{
    public class BaseGameComponentsInstaller : MonoInstaller
    {
        [SerializeField]
        private MapsContainer _mapsContainer;

        [SerializeField]
        private ScenesLoader _scenesLoader;

        public override void InstallBindings()
        {
            Container.Bind<MapsContainer>().FromScriptableObject(_mapsContainer).AsSingle().NonLazy();
            Container.BindInstance(_scenesLoader).AsSingle().NonLazy();
        }
    }
}