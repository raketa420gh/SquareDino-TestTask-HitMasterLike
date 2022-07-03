using System.Collections.Generic;

public interface IWaypointWithEnemies : IWaypoint
{
    List<SpawnPoint> EnemySpawnPoints { get; }
}