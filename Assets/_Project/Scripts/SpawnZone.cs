using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public float Radius = 2;

    public Vector3 GetSpawnPosition => transform.position + (Random.insideUnitSphere * Radius);

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}