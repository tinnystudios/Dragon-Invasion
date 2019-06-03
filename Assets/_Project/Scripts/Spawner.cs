using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour, IBind<BowHeroCharacter>
{
    public BowHeroCharacter _bowHeroCharacter { get; set; }

    public List<SpawnZone> Zones;

    public Action<Enemy> OnSpawn;

    /// <summary>
    /// Track a list of enemies the spawner has made
    /// </summary>
    private List<Enemy> _enemies = new List<Enemy>();

    /// <summary>
    /// All enemies have died
    /// </summary>
    public bool Empty => State == EState.Running && _enemies.Count == 0;

    /// <summary>
    /// Select a zone randomly
    /// </summary>
    public SpawnZone SelectRandomZone => Zones[Random.Range(0, Zones.Count)];

    /// <summary>
    /// The state the spawner is in
    /// </summary>
    public EState State { get; private set; }

    public void Bind(BowHeroCharacter dependent) => _bowHeroCharacter = dependent;

    public IEnumerator Spawn(Enemy enemy, float rate)
    {
        if (enemy == null)
            yield break;

        State = EState.Running;

        yield return new WaitForSeconds(rate);

        var spawnZone = SelectRandomZone;
        var spawnDirection = spawnZone.GetSpawnPosition - Camera.main.transform.position;
        spawnDirection.Normalize();

        var instance = Instantiate(enemy, spawnZone.GetSpawnPosition, Quaternion.identity);
        instance.OnDeath += OnEnemyDeath;

        instance.Bind(_bowHeroCharacter);

        OnSpawn?.Invoke(instance);
        _enemies.Add(instance);
    }

    private void OnEnemyDeath(Enemy enemy)
    {
        Debug.Log($"Enemy Died");

        enemy.OnDeath -= OnEnemyDeath;
        _enemies.Remove(enemy);

        Debug.Log($"Enemy Count: {_enemies.Count}");

        if (Empty)
        {
            Debug.Log("[Spawner] Ended");
            State = EState.Ended;
        }
    }
}