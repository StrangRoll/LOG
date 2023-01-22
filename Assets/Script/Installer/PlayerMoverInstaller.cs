using UnityEngine;
using Zenject;

namespace Script.Installer
{
    public class PlayerMoverInstaller : MonoInstaller
    {
        [SerializeField] private PlayerMover playerMover;

        public override void InstallBindings()
        {
            Container
                .Bind<PlayerMover>()
                .FromInstance(playerMover)
                .AsSingle();
        }
    }
}