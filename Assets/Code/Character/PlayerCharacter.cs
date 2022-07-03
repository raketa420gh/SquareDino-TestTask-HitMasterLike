using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(CharacterAnimation))]

public class PlayerCharacter : Character
{
    public StateMachine StateMachine;
    public IdleState IdleState;
    public MoveState MoveState;
    
    private ICharacterMovement _movement;
    private ICharacterAnimation _animation;
    
    private void Awake()
    {
        _movement = GetComponent<ICharacterMovement>();
        _animation = GetComponent<ICharacterAnimation>();
    }

    private void Start() => InitializeStateMachine();

    private void Update() => StateMachine.CurrentState.Update();

    private void FixedUpdate() => StateMachine.CurrentState.FixedUpdate();

    public void MoveTo(Vector3 position)
    {
        _movement.AIPath.destination = position;
        StateMachine.ChangeState(MoveState);
    }

    private void InitializeStateMachine()
    {
        StateMachine = new StateMachine();
        IdleState = new IdleState(StateMachine, this, _movement, _animation);
        MoveState = new MoveState(StateMachine, this, _movement, _animation);
        StateMachine.ChangeState(IdleState);
    }
}