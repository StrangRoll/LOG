using Script.Shoot.Devices;
using UnityEngine;
using Zenject;

namespace Script.Installer
{
    public class BulletCollectorInstaller : MonoInstaller
    {
        [SerializeField] private BulletCollector bulletCollector;
    
        public override void InstallBindings()
        {
            Container
                .Bind<BulletCollector>()
                .FromInstance(bulletCollector)
                .AsSingle();
        }
    }
}