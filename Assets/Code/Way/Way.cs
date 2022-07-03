using System.Collections.Generic;
using UnityEngine;

public class Way : MonoBehaviour, IWay
{
    [SerializeField] private List<Waypoint> _way;
    private int _currentWaypointIndex = 0;

    public List<Waypoint> AllWaypoints => _way;
    public Waypoint CurrentWaypoint { get; private set; }
    public Waypoint NextWaypoint { get; private set; }
    
    public bool IsFinished { get; private set; }

    private void Awake() => Setup();

    public void ReachWaypoint()
    {
        if (_currentWaypointIndex >= _way.Capacity)
        {
            Debug.Log("Last point reached");
            return;
        }

        _currentWaypointIndex++;
        CurrentWaypoint = NextWaypoint;
        
        UpdateWayStep();
    }

    private void Setup()
    {
        if (_way.Count == 0)
        {
            var waypoints = GetComponentsInChildren<Waypoint>();
            _way.AddRange(waypoints);
        }
        
        IsFinished = false;
        CurrentWaypoint = _way[_currentWaypointIndex];
        UpdateWayStep();
    }

    private void UpdateWayStep()
    {
        if (_currentWaypointIndex >= _way.Count - 1)
        {
            Debug.Log("Way Finished");
            IsFinished = true;
        }
        else
        {
            NextWaypoint = _way[_currentWaypointIndex + 1];
            Debug.Log($"Current wp = {CurrentWaypoint.gameObject.name}, Next wp = {NextWaypoint.gameObject.name}");
        }
    }
}