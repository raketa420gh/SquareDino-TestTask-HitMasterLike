using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool IsOccupied { get; set; }

    public Vector3 GetPosition => transform.position;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(GetPosition, 0.15f);
    }
}