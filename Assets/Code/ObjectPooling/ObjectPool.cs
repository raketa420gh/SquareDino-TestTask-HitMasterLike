using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private ShellsPool _shellsPool;

    private void Awake()
    {
        _shellsPool = GetComponent<ShellsPool>();
    }

    private void Start()
    {
        _shellsPool.CreateObjects();
    }
    
    public Shell CreateShell(Vector3 position) => _shellsPool.CreateShell(position);
}