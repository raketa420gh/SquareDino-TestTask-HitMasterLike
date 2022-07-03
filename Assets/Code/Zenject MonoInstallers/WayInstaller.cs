using Zenject;

public class WayInstaller : MonoInstaller
{
    public Way Way;
    
    public override void InstallBindings() =>
        Bind();
    
    private void Bind()
    {
        Container
            .Bind<Way>()
            .FromInstance(Way)
            .AsSingle()
            .NonLazy();
    }
}