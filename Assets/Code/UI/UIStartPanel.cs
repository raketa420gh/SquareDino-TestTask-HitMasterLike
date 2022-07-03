using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]

public class UIStartPanel : UIPanel
{
    private Button _startButton;
    private ILevelLoop _levelLoop;

    [Inject]
    public void Construct(ILevelLoop levelLoop) => _levelLoop = levelLoop;

    private void Awake()
    {
        _startButton = GetComponent<Button>();
        _startButton.onClick.AddListener((StartLevel));
    }

    private void StartLevel()
    {
        _levelLoop.StartLevel();
        gameObject.SetActive(false);
    }
}