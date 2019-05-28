using System.Collections;

public class WaveStage : StageBase
{
    public WaveModel Model;
    public Spawner Spawner;

    public override IEnumerator Run()
    {
        while (true)
        {
            yield return Spawner.Spawn(Model.GetEnemy(), Model.SpawnRate());
        }
    }
}