using UnityEngine;

public abstract class GrabHandler : MonoBehaviour
{
    public IGrabber Grabber { get; protected set; }

    public abstract bool CanGrab { get; }
    public abstract bool CanDetatch { get; }

    public abstract void AttachTo(IGrabber grabber);
    public abstract void Detatch(IGrabber grabber);
}