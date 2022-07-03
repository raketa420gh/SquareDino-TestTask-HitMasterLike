using UnityEngine.UI;
using Zenject;

public class UIFinishPanel : UIPanel
{
    private Button _restartButton;
    private SceneLoader _sceneLoader;

    [Inject]
    public void Construct(SceneLoader sceneLoader) => _sceneLoader = sceneLoader;

    private void Awake()
    {
        _restartButton = GetComponent<Button>();
        _restartButton.onClick.AddListener((RestartScene));
    }

    private void RestartScene() => _sceneLoader.RestartScene();
}