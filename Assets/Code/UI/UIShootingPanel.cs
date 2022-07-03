using System;
using UnityEngine.UI;

public class UIShootingPanel : UIPanel
{
    public event Action OnClick;
    
    private Button _startButton;

    private void Awake()
    {
        _startButton = GetComponent<Button>();
        _startButton.onClick.AddListener((Click));
    }

    private void Click() => OnClick?.Invoke();
}