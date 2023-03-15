using UnityEngine;
using Zenject;

namespace Script.Installer
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private Camera mainCamera;
    
        public override void InstallBindings()
        {
            Container
                // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
                .Bind<Camera>()
                .FromInstance(mainCamera)
                .AsSingle();
        }
    }
}