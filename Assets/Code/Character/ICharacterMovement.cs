using Pathfinding;
using UnityEngine;

public interface ICharacterMovement
{
    public AIPath AIPath { get; }
    void MoveTo(Vector3 position);
}