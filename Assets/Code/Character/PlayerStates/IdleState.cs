using UnityEngine;

public class IdleState : BaseState
{
    private PlayerCharacter _playerCharacter;
    private ICharacterMovement _movement;
    private ICharacterAnimation _animation;
    
    public IdleState(StateMachine stateMachine,
        PlayerCharacter playerCharacter,
        ICharacterMovement movement,
        ICharacterAnimation animation)
    {
        _playerCharacter = playerCharacter;
        _movement = movement;
        _animation = animation;
    }

    public override void Enter()
    {
        base.Enter();
        _animation.ActivateTrigger(AnimationNames.Idle);
    }

    public override void Update()
    {
        base.Update();
        
        if(_movement.AIPath.desiredVelocity.magnitude > _movement.AIPath.speed/2)
            _playerCharacter.StateMachine.ChangeState(_playerCharacter.MoveState);
    }
}