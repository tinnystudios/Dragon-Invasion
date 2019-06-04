using System.Collections;
using UnityEngine;

/// <summary>
/// The wave stage will run until all enemies are dead
/// </summary>
public class WaveStage : StageBase
{
    public WaveBaseModel Model;
    public Spawner Spawner;

    public EState State { get; private set; }

    public override IEnumerator Run()
    {
        Model.Clear();

        while (Model.Progress < 1)
        {
            yield return Spawner.Spawn(Model.GetEnemyPrefab(), Model.SpawnRate());
            yield return null;
        }

        // Make sure all enemies are dead
        yield return new WaitUntil(() => Spawner.State == EState.Ended);
    }
}