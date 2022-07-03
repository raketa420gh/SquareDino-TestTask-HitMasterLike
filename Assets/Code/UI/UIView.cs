using UnityEngine;

public class UIView : MonoBehaviour
{
    [SerializeField] private UIStartPanel _startPanel;
    [SerializeField] private UIShootingPanel _shootingPanel;
    [SerializeField] private UIFinishPanel _finishPanel;

    public UIShootingPanel ShootingPanel => _shootingPanel;
    public UIFinishPanel FinishPanel => _finishPanel;

    private void Start() => SetStartView();

    private void SetStartView()
    {
        _startPanel.Show();
        _finishPanel.Hide();
        _shootingPanel.Hide();
    }
}