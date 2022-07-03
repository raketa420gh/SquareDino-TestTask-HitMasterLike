using UnityEngine;
using Zenject;

public class Factory : IFactory
{
    private AssetProvider _assetProvider;

    [Inject]
    public void Construct(AssetProvider assetProvider) =>
        _assetProvider = assetProvider;

    public ParticleSystem CreateVFX(Vector3 position, string path = AssetPath.VFX, Transform parent = null)
    {
        GameObject obj = CreateGameObject(position, path, parent);
        var particleSystem = obj.GetComponentInChildren<ParticleSystem>();
        return particleSystem;
    }

    public AudioSource CreateSFX(Vector3 position, string path = AssetPath.SFX, Transform parent = null)
    {
        GameObject obj = CreateGameObject(position, path, parent);
        var audioSource = obj.GetComponentInChildren<AudioSource>();
        return audioSource;
    }

    public PlayerCharacter CreatePlayerCharacter(Vector3 position, string path = AssetPath.PlayerCharacter, Transform parent = null)
    {
        GameObject obj = CreateGameObject(position, path, parent);
        var hero = obj.GetComponent<PlayerCharacter>();
        return hero;
    }

    public Enemy CreateEnemy(Vector3 position, string path = AssetPath.Enemy, Transform parent = null)
    {
        GameObject obj = CreateGameObject(position, path, parent);
        var enemy = obj.GetComponent<Enemy>();
        return enemy;
    }

    public IProjectile CreateShell(Vector3 position, string path = AssetPath.Shell, Transform parent = null)
    {
        GameObject obj = CreateGameObject(position, path, parent);
        var projectile = obj.GetComponent<IProjectile>();
        return projectile;
    }

    private GameObject CreateGameObject(Vector3 position, string path, Transform parent)
    {
        GameObject obj = _assetProvider.Instantiate(path, position);
        obj.transform.SetParent(parent);
        return obj;
    }
}