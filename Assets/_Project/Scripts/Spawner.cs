using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy EnemyPrefab;

    public List<SpawnZone> Zones;
    public SpawnerSettings Settings;

    public SpawnZone SelectSpawnZone => Zones[Random.Range(0, Zones.Count)];

    private void Awake()
    {
        StartCoroutine(Run());
    }

    private IEnumerator Run()
    {
        while (true)
        {
            yield return Spawn();
        }
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Settings.Rate);
        var spawnZone = SelectSpawnZone;
        var spawnDirection = spawnZone.GetSpawnPosition - Camera.main.transform.position;
        spawnDirection.Normalize();

        var instance = Instantiate(EnemyPrefab, spawnZone.GetSpawnPosition, Quaternion.identity);
    }
}