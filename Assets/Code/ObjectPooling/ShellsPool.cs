using UnityEngine;

public class ShellsPool : MonoBehaviour
{
    [SerializeField] private int _poolCount = 15;
    [SerializeField] private bool _autoExpandEnabled = true;
    [SerializeField] private Shell _shellPrefab;

    private PoolMono<Shell> _pool;

    public void CreateObjects()
    {
        _pool = new PoolMono<Shell>(_shellPrefab, _poolCount, transform);
        _pool.AutoExpandEnabled = _autoExpandEnabled;
    }

    public Shell CreateShell(Vector3 position)
    {
        var shell = _pool.GetFreeElement();
        shell.transform.position = position;

        return shell;
    }
}