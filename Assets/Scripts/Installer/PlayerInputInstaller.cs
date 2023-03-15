using Zenject;

public class PlayerInputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var playerInput = new PlayerInput();

        Container
            .Bind<PlayerInput>()
            .FromInstance(playerInput)
            .AsSingle();
    }
}