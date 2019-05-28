using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<SpawnZone> Zones;

    public SpawnZone SelectSpawnZone => Zones[Random.Range(0, Zones.Count)];

    public IEnumerator Spawn(Enemy enemy, float rate)
    {
        yield return new WaitForSeconds(rate);
        var spawnZone = SelectSpawnZone;
        var spawnDirection = spawnZone.GetSpawnPosition - Camera.main.transform.position;
        spawnDirection.Normalize();

        var instance = Instantiate(enemy, spawnZone.GetSpawnPosition, Quaternion.identity);
    }
}