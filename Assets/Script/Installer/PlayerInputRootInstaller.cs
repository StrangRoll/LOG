using Script.Input;
using UnityEngine;
using Zenject;

namespace Script.Installer
{
    public class PlayerInputRootInstaller : MonoInstaller
    {
        [SerializeField] private PlayerInputRoot inputRoot;
        
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            Container
                .Bind<PlayerInputRoot>()
                .FromInstance(inputRoot)
                .AsSingle();
        }
    }
}