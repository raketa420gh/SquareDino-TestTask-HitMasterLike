using Pathfinding;
using UnityEngine;

[RequireComponent(typeof(AIPath))]
[RequireComponent(typeof(Seeker))]

public class CharacterMovement : MonoBehaviour, ICharacterMovement
{
    private AIPath _aiPath;

    public AIPath AIPath => _aiPath;

    private void Awake() => 
        _aiPath = GetComponent<AIPath>();

    public void MoveTo(Vector3 position) => 
        _aiPath.Move(position * Time.fixedDeltaTime);
}