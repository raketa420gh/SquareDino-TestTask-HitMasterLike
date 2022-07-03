using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _foregroundImage;
    [SerializeField] [Min(0)] private float updateSpeedSeconds = 0.25f;
    private Health _health;

    private void Awake()
    {
        _health = GetComponentInParent<Health>();
        GetComponent<Canvas>().worldCamera = Camera.main;
    }

    private void OnEnable() => _health.OnPercentChanged += OnPercentChanged;

    private void OnDisable() => _health.OnPercentChanged -= OnPercentChanged;

    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0,180, 0);
    }

    private IEnumerator ChangeToCurrentPercent(float currentHealthPercent)
    {
        float preChangePercent = _foregroundImage.fillAmount;
        float elapsed = 0f;

        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            _foregroundImage.fillAmount =
                Mathf.Lerp(preChangePercent, currentHealthPercent, elapsed / updateSpeedSeconds);
            yield return null;
        }

        _foregroundImage.fillAmount = currentHealthPercent;
    }

    private void OnPercentChanged(float currentHealthPercent) => 
        StartCoroutine(ChangeToCurrentPercent(currentHealthPercent));
}