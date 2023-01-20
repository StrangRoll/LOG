using UnityEngine;
using Zenject;

public class PlayerMovierInstaller : MonoInstaller
{
    [SerializeField] private PlayerMovier _playerMovier;

    public override void InstallBindings()
    {
        Container
            .Bind<PlayerMovier>()
            .FromInstance(_playerMovier)
            .AsSingle();
    }
}