using Zenject;

public class ObjectPoolInstaller : MonoInstaller
{
    public ObjectPool ObjectPool;
    
    public override void InstallBindings() =>
        Bind();
    
    private void Bind()
    {
        Container
            .Bind<ObjectPool>()
            .FromInstance(ObjectPool)
            .AsSingle()
            .NonLazy();
    }
}