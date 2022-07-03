using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class Waypoint : MonoBehaviour, IWaypointWithEnemies
{
    public event Action OnPlayerReached;
        
    [SerializeField] private List<SpawnPoint> _enemySpawnPoints;
    
    public Vector3 GetPosition() => transform.position;
    public List<SpawnPoint> EnemySpawnPoints => _enemySpawnPoints;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(GetPosition(), 0.3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerCharacter>();
        
        if (player)
            OnPlayerReached?.Invoke();
    }
}