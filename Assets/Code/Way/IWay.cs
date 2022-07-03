using System.Collections.Generic;

public interface IWay
{
    List<Waypoint> AllWaypoints { get; }
    Waypoint CurrentWaypoint { get; }
    Waypoint NextWaypoint { get; }
    void ReachWaypoint();
}