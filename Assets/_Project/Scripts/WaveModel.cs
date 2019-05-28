using System.Collections.Generic;
using UnityEngine;

// TODO: WaveModel need to be abstract and allow different way of setting up enemies
[CreateAssetMenu]
public class WaveModel : ScriptableObject
{
    public SpawnerSettings SpawnerSettings;
    public AnimationCurve DifficultyCurve;

    public int Count = 20;
    public List<EnemyChance> Enemies;

    private int _enemyCount = 0;

    public float Progress => _enemyCount / (float)Count;
    public float SpawnRate() => SpawnerSettings.GetRate(DifficultyCurve, Progress);

    public Enemy GetEnemy()
    {
        _enemyCount++;
        return RandomUtils.GetByProbability(Enemies).Enemy;
    }
}