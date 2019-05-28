using System;

[Serializable]
public class EnemyChance : IChance
{
    public Enemy Enemy;
    public int Weight;

    public int Priority => this.Weight;
}
