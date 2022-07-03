using UnityEngine;

public interface IFactory
{
    PlayerCharacter CreatePlayerCharacter(Vector3 position, string path = AssetPath.PlayerCharacter, Transform parent = null);
    Enemy CreateEnemy(Vector3 position, string path = AssetPath.Enemy, Transform parent = null);
    IProjectile CreateShell(Vector3 position, string path = AssetPath.Shell, Transform parent = null);

}