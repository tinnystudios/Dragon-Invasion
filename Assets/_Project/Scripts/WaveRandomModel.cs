using UnityEngine;

/// <summary>
/// A Wave model providing enemies based on probability
/// </summary>
[CreateAssetMenu]
public class WaveRandomModel : WaveBaseModel
{
    public int TotalEnemies = 20;
    private int _enemyCount = 0;

    public override float Progress => _enemyCount / (float)TotalEnemies;

    public override Enemy GetEnemy()
    {
        _enemyCount++;
        return RandomUtils.GetByProbability(Enemies).Enemy;
    }
}