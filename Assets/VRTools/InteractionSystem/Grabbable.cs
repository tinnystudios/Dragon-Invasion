using System;
using UnityEngine;

/// <summary>
/// A component to be grabbed by a grabber
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Grabbable : MonoBehaviour, IGrabbable
{
    public Action<IGrabber> OnAttach;
    public Action<IGrabber> OnDetatch;

    public IGrabber Grabber => GrabHandler.Grabber;
    public bool CanGrab => GrabHandler.CanGrab;
    public bool CanDetatch => GrabHandler.CanDetatch;

    public GrabHandler GrabHandler;

    public void AttachTo(IGrabber grabber)
    {
        GrabHandler.AttachTo(grabber);
        OnAttach?.Invoke(grabber);
    }

    public void Detatch(IGrabber grabber)
    {
        GrabHandler.Detatch(grabber);
        OnDetatch?.Invoke(grabber);
    }
}
