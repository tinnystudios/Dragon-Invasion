using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody _rigidBody;

    public bool FoundNotch { get; private set; }
    public bool IsFlying { get; private set; }

    public Grabbable Grabbable { get; private set; }

    private void Awake()
    {
        Grabbable = GetComponent<Grabbable>();
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void Found(BowNotch notch)
    {
        FoundNotch = true;
    }

    public void Fire(float velocity)
    {
        IsFlying = true;

        _rigidBody.useGravity = true;
        _rigidBody.isKinematic = false;
        _rigidBody.velocity = transform.forward * velocity;

        var grabber = (Grabber)Grabbable?.Grabber;
        grabber?.Detatch(Grabbable);

        Debug.Log($"Fire Velocity: {velocity}");
    }
}