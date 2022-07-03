using Zenject;

public class UIViewInstaller : MonoInstaller
{
    public UIView UIView;
    
    public override void InstallBindings() =>
        Bind();
    
    private void Bind()
    {
        Container
            .Bind<UIView>()
            .FromInstance(UIView)
            .AsSingle()
            .NonLazy();
    }
}