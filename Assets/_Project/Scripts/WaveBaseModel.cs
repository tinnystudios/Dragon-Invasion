using System.Collections.Generic;
using UnityEngine;

public abstract class WaveBaseModel : ScriptableObject
{
    public SpawnerSettings SpawnerSettings;

    public AnimationCurve DifficultyCurve;
    public List<EnemyChance> Enemies;

    public abstract float Progress { get; }
    public abstract float SpawnRate();
    public abstract Enemy GetEnemy();
}