using Script.Mover;
using Script.Mover.Player;
using UnityEngine;
using Zenject;

namespace Script.Installer
{
    public class PlayerMoverInstaller : MonoInstaller
    {
        [SerializeField] private PlayerMover playerMover;

        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            Container
                .Bind<PlayerMover>()
                .FromInstance(playerMover)
                .AsSingle();
        }
    }
}