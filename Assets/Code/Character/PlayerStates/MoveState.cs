using UnityEngine;

public class MoveState : BaseState
{
    private PlayerCharacter _playerCharacter;
    private ICharacterMovement _movement;
    private ICharacterAnimation _animation;

    public MoveState(StateMachine stateMachine, 
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
        _animation.ActivateTrigger(AnimationNames.Running);
    }

    public override void Update()
    {
        base.Update();
        
        if(_movement.AIPath.desiredVelocity.magnitude < _movement.AIPath.speed/2)
            _playerCharacter.StateMachine.ChangeState(_playerCharacter.IdleState);
    }
}