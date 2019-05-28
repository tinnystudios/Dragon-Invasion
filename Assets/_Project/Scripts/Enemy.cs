using UnityEngine;

public class Enemy : MonoBehaviour
{
    public LayerMask DamageLayer;
    public float MoveSpeed = 1;

    private void Update()
    {
        var cam = Camera.main.transform;
        var target = cam.position;

        transform.LookAt(target);
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        var hits = Physics.OverlapSphere(transform.position, 0.5F, DamageLayer);

        // #TODO Health Script
        if (hits.Length > 0)
        {
            Destroy(gameObject);
        }
    }
}
