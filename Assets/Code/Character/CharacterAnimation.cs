using UnityEngine;

public class CharacterAnimation : MonoBehaviour, ICharacterAnimation
{
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        if (!_animator)
            _animator = GetComponent<Animator>();
    }

    public void ActivateTrigger(string name) => _animator.SetTrigger(name);
}