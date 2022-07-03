using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelLoop : ILevelLoop
{
    private ObjectPool _objectPool;
    private IFactory _factory;
    private CameraController _camera;
    private UIView _ui;
    private PlayerCharacter _player;
    private Way _way;
    private List<Enemy> _currentEnemies = new List<Enemy>();
    private int _currentEnemiesCount = 0;

    [Inject]
    public void Construct(IFactory factory, ObjectPool objectPool, CameraController camera, UIView ui, PlayerCharacter player, Way way)
    {
        _factory = factory;
        _objectPool = objectPool;
        _camera = camera;
        _ui = ui;
        _player = player;
        _way = way;

        ui.ShootingPanel.OnClick += Shoot;
    }

    public void StartLevel() => StartNextStep();

    private void StartNextStep()
    {
        _ui.ShootingPanel.Hide();
        
        if (!_way.IsFinished)
        {
            _way.NextWaypoint.OnPlayerReached += OnPlayerReachedWaypoint;

            CreateEnemiesForNextWaypoint();

            foreach (var enemy in _currentEnemies)
                enemy.OnDead += OnEnemyDead;

            MovePlayerToNextWaypoint();
            
            _camera.ComposerLookAt(_player.transform);
            _camera.SetComposerTrackedObjectOffsetY(2);
        }
        else
            ShowFinishPanel();
    }

    private void ShowFinishPanel() => _ui.FinishPanel.Show();

    private void MovePlayerToNextWaypoint() => _player.MoveTo(_way.NextWaypoint.GetPosition());

    private void CreateEnemiesForNextWaypoint()
    {
        List<Enemy> nextWaypointEnemies = new List<Enemy>();
        
        foreach (var spawnPoint in _way.NextWaypoint.EnemySpawnPoints)
        {
            var enemy = _factory.CreateEnemy(spawnPoint.GetPosition);
            enemy.gameObject.transform.Rotate(0, 180, 0);
            enemy.Setup(100);
            nextWaypointEnemies.Add(enemy);
        }

        _currentEnemies = nextWaypointEnemies;
        _currentEnemiesCount = _currentEnemies.Count;
    }

    private void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Debug.DrawLine(ray.origin, ray.direction * 100f, Color.yellow);
            var shell = _objectPool.CreateShell(ray.origin);
            shell.SetTargetPosition(hitInfo.point);
        }
    }

    private void OnEnemyDead(Enemy enemy)
    {
        _currentEnemiesCount--;

        if (_currentEnemiesCount <= 0)
        {
            _currentEnemiesCount = 0;
            StartNextStep();
        }
    }

    private void OnPlayerReachedWaypoint()
    {
        _camera.ComposerLookAt(_way.NextWaypoint.EnemySpawnPoints[1].transform);
        _camera.SetComposerTrackedObjectOffsetY(0);
        _ui.ShootingPanel.Show();
        _way.NextWaypoint.OnPlayerReached -= OnPlayerReachedWaypoint;
        _way.ReachWaypoint();
    }
}