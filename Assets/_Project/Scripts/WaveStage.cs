using System.Collections;

public class WaveStage : StageBase
{
    public WaveModel Model;
    public Spawner Spawner;

    public override IEnumerator Run()
    {
        while (true)
        {
            var enemy = RandomUtils.GetByProbability(Model.Enemies).Enemy;
            yield return Spawner.Spawn(enemy);
        }
    }
}
