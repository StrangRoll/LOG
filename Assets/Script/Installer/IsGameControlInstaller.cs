using Script.GameEntitie;
using Script.System;
using Script.Wave;
using UnityEngine;
using Zenject;

namespace Script.Installer
{
    public class IsGameControlInstaller : MonoInstaller
    {
        [SerializeField] private WavesController wavesController;
        [SerializeField] private Player player;

        public override void InstallBindings()
        {
            var isGameControl = new IsGameControl(wavesController, player);
        
            Container
                .Bind<IsGameControl>()
                .FromInstance(isGameControl)
                .AsSingle();
        }
    }
}