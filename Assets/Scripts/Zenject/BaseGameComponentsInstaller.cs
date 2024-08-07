using DungeonAndDemons.Game;
using DungeonAndDemons.ScriptableObjects;
using DungeonAndDemons.ScriptableObjects.Containers;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace DungeonAndDemons.Zenject
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