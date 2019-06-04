using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Fireball : MonoBehaviour
{
    public Rigidbody Rigidbody;

    public void Fire(Vector3 velocity)
    {
        Rigidbody.velocity = velocity;
    }
}
