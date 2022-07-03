using Zenject;

public class PlayerCharacterInstaller : MonoInstaller
{
    public PlayerCharacter PlayerCharacter;
    
    public override void InstallBindings() =>
        Bind();
    
    private void Bind()
    {
        Container
            .Bind<PlayerCharacter>()
            .FromInstance(PlayerCharacter)
            .AsSingle()
            .NonLazy();
    }
}