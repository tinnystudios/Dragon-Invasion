using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class WaveBaseModel : ScriptableObject
{
    [Header("Base Configuration")]
    public SpawnerSettings SpawnerSettings;

    /// <summary>
    /// A curve to be evaluated by the Progress to determine the spawn rate and possibly other features
    /// </summary>
    public AnimationCurve DifficultyCurve = AnimationCurve.Linear(0,0,1,1);
    
    /// <summary>
    /// The list of enemies to spawn, this varies from model to model
    /// </summary>
    public List<WaveEnemyModel> Enemies;

    /// <summary>
    /// How far in the wave are we? 0 - 1
    /// </summary>
    public abstract float Progress { get; }

    /// <summary>
    /// The rate at which the spawner should spawn the enemies
    /// </summary>
    /// <returns></returns>
    public virtual float SpawnRate() => SpawnerSettings.GetRate(DifficultyCurve, Progress);

    /// <summary>
    /// Returns an enemy depending the implementation
    /// </summary>
    /// <returns></returns>
    public abstract Enemy GetEnemyPrefab();

    /// <summary>
    /// Clear any persistent settings
    /// </summary>
    public abstract void Clear();
}