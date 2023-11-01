using ClansWars.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BaseGameComponentsInstaller : MonoInstaller
{
    [SerializeField]
    private ScenesLoader _scenesLoader;

    public override void InstallBindings()
    {
        Container.BindInstance(_scenesLoader).AsSingle().NonLazy();
    }
}
