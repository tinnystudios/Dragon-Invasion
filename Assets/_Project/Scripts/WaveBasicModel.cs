using UnityEngine;

/// <summary>
/// The basic wave model provides enemies linearly based on the order
/// </summary>
[CreateAssetMenu]
public class WaveBasicModel : WaveBaseModel
{
    private int _enemyCount = 0;

    public override float Progress => _enemyCount / (float)Enemies.Count;

    public override void Clear()
    {
        _enemyCount = 0;
    }

    public override Enemy GetEnemyPrefab()
    {
        var enemy = Enemies[_enemyCount].Enemy;
        _enemyCount++;

        Debug.Log(enemy.transform.name);

        Debug.Log("Progress " + Progress);
        return enemy;
    }
}