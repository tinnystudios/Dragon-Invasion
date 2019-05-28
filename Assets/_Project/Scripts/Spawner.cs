using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public SpawnerSettings Settings;
    public List<SpawnZone> Zones;

    public SpawnZone SelectSpawnZone => Zones[Random.Range(0, Zones.Count)];

    public IEnumerator Spawn(Enemy enemy)
    {
        yield return new WaitForSeconds(Settings.Rate);
        var spawnZone = SelectSpawnZone;
        var spawnDirection = spawnZone.GetSpawnPosition - Camera.main.transform.position;
        spawnDirection.Normalize();

        var instance = Instantiate(enemy, spawnZone.GetSpawnPosition, Quaternion.identity);
    }
}