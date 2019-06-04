using System;
using UnityEngine;

[Serializable]
public class WaveEnemyModel : IChance
{
    public string Name = "Enemy";

    public Enemy Enemy;

    [Range(0,100)]
    public int Weight;

    public int Priority => this.Weight;
}