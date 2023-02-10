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
        [SerializeField] private RectTransform mainMenu;

        public override void InstallBindings()
        {
            var isGameControl = new IsGameControl(wavesController, player, mainMenu);
        
            Container
                .Bind<IsGameControl>()
                .FromInstance(isGameControl)
                .AsSingle();
        }
    }
}