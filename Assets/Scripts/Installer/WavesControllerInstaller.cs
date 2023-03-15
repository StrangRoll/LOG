using Script.Wave;
using UnityEngine;
using Zenject;

public class WavesControllerInstaller : MonoInstaller
{
    [SerializeField] private WavesController wavesController;
    
    public override void InstallBindings()
    {
        Container
            .Bind<WavesController>()
            .FromInstance(wavesController)
            .AsSingle();
    }
}