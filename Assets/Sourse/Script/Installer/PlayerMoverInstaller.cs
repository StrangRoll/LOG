using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

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