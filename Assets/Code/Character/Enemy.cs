using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CharacterRagdoll))]
[RequireComponent(typeof(Health))]

public class Enemy : Character
{
    public event Action<Enemy> OnDead;

    private Health _health;
    private HealthBar _healthBar;
    private CharacterRagdoll _ragdoll;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _healthBar = GetComponentInChildren<HealthBar>();
        _ragdoll = GetComponent<CharacterRagdoll>();
    }

    private void OnEnable() => _health.OnOver += OnHealthOver;

    private void OnDisable() => _health.OnOver -= OnHealthOver;

    public void Setup(int maxHealth)
    {
        _health.Setup(maxHealth);
        _ragdoll.Deactivate();
    }

    private void Die()
    {
        _ragdoll.Activate();
        _healthBar.gameObject.SetActive(false);
        OnDead?.Invoke(this);
        Destroy(this);
    }

    private void OnHealthOver() =>
        Die();
}