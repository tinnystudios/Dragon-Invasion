using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A component to enable grabbing grabbables
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Grabber : MonoBehaviour, IGrabber
{
    public EHandedness Handedness;
    public GrabberInput GrabberInput = new GrabberInput();

    public Action<IGrabbable> OnGrabAttach { get; set; }
    public Action<IGrabbable> OnGrabDetatch { get; set; }

    public Action OnRelease { get; set; }

    public LayerMask LayerMask;

    [Range(0.2F, 2)]
    public float Radius = 0.2F;

    public bool CanGrabMultiple = false;

    public EHandedness Hand => Handedness;

    public bool IsGrabbing => GrabberInput.IsGrabbing(Hand);
    public bool GrabUp => GrabberInput.IsGrabUp(Hand);

    private List<IGrabbable> _grabbables = new List<IGrabbable>();
    private Collider[] _colliderResults = new Collider[6];

    private void Update()
    {
        Cast();

        if (GrabberInput.IsGrabUp(Hand) && _grabbables.Count > 0)
        {
            Release();
        }
    }

    private void Cast()
    {
        if (_grabbables.Count > 0 && !CanGrabMultiple)
            return;

        var hitCount = Physics.OverlapSphereNonAlloc(
            transform.position,
            Radius,
            _colliderResults,
            LayerMask);

        for (int i = 0; i < hitCount; i++)
        {
            var collider = _colliderResults[i];

            if (!collider.isTrigger)
                continue;

            TryGrab(collider);
        }
    }

    private void TryGrab(Collider collider)
    {
        var grabbable = collider.GetComponentInParent<IGrabbable>();

        if (_grabbables.Contains(grabbable) || grabbable != null && !grabbable.CanGrab)
            return;

        if (grabbable != null && GrabberInput.IsGrabbing(Handedness))
        {
            Grab(grabbable);
        }
    }

    public void Grab(IGrabbable grabbable)
    {
        grabbable.AttachTo(this);
        _grabbables.Add(grabbable);

        OnGrabAttach?.Invoke(grabbable);
    }

    public void Release()
    {
        var toRemove = new List<IGrabbable>();
        foreach (var grabbable in _grabbables)
        {
            if (!grabbable.CanDetatch)
                continue;

            grabbable.Detatch(this);
            toRemove.Add(grabbable);
        }

        foreach (var grabbable in toRemove)
        {
            _grabbables.Remove(grabbable);
        }

        OnRelease?.Invoke();
    }

    public void Detatch(IGrabbable grabbable)
    {
        grabbable.Detatch(this);
        _grabbables.Remove(grabbable);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}