using Script.GameEntitie;
using UnityEngine;
using Zenject;

public class PlayerScriptInstaller : MonoInstaller
{
    [SerializeField] private Player player;

    public override void InstallBindings()
    {
        Container
            .Bind<Player>()
            .FromInstance(player)
            .AsSingle();
    }
}