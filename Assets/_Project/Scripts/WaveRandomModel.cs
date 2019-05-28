using UnityEngine;

/// <summary>
/// A Wave model providing enemies based on probability
/// </summary>
[CreateAssetMenu]
public class WaveRandomModel : WaveBaseModel
{
    public int Count = 20;
    private int _enemyCount = 0;

    public override float Progress => _enemyCount / (float)Count;
    public override float SpawnRate() => SpawnerSettings.GetRate(DifficultyCurve, Progress);

    public override Enemy GetEnemy()
    {
        _enemyCount++;
        return RandomUtils.GetByProbability(Enemies).Enemy;
    }
}