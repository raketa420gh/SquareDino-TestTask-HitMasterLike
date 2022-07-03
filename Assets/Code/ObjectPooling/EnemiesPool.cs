using UnityEngine;

public class EnemiesPool : MonoBehaviour
{
    [SerializeField] private int _poolCount = 15;
    [SerializeField] private bool _autoExpandEnabled = true;
    [SerializeField] private Enemy _enemyPrefab;

    private PoolMono<Enemy> _pool;

    public void CreateObjects()
    {
        _pool = new PoolMono<Enemy>(_enemyPrefab, _poolCount, transform);
        _pool.AutoExpandEnabled = _autoExpandEnabled;
    }

    public Enemy CreateEnemy(Vector3 position)
    {
        var enemy = _pool.GetFreeElement();
        enemy.transform.position = position;

        return enemy;
    }
}