using UnityEngine;

/// <summary>
/// The basic wave model provides enemies linearly based on the order
/// </summary>
[CreateAssetMenu]
public class WaveBasicModel : WaveBaseModel
{
    private int _enemyCount = 0;

    public override float Progress => _enemyCount / (float)Enemies.Count;

    public override Enemy GetEnemy()
    {
        var enemy = Enemies[_enemyCount].Enemy;
        _enemyCount++;
        return enemy;
    }
}