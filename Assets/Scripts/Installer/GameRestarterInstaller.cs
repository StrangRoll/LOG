using Script.System;
using UnityEngine;
using Zenject;

public class GameRestarterInstaller : MonoInstaller
{
    [SerializeField] private GameRestarter gameRestarter;
    
    public override void InstallBindings()
    {
        Container
            .Bind<GameRestarter>()
            .FromInstance(gameRestarter)
            .AsSingle();
    }
}