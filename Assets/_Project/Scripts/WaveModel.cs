using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WaveModel : ScriptableObject
{
    public int Count = 20;
    public List<EnemyChance> Enemies;
}
