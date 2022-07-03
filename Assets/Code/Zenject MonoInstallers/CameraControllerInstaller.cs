using Zenject;

public class CameraControllerInstaller : MonoInstaller
{
    public CameraController CameraController;
    
    public override void InstallBindings() =>
        Bind();
    
    private void Bind()
    {
        Container
            .Bind<CameraController>()
            .FromInstance(CameraController)
            .AsSingle()
            .NonLazy();
    }
}