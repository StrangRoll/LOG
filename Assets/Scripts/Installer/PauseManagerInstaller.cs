using Script.Pause;
using UnityEngine;
using Zenject;

public class PauseManagerInstaller : MonoInstaller
{
    [SerializeField] private PauseManager pauseManager;
    
    public override void InstallBindings()
    {
        Container
            .Bind<PauseManager>()
            .FromInstance(pauseManager)
            .AsSingle();
    }
}