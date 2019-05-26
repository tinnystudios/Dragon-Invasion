using UnityEngine;

public class BasicGrabHandler : GrabHandler
{
    public override bool CanGrab => Grabber == null;
    public override bool CanDetatch => true;

    public bool KeepWorldTransform = true;

    private Transform _parentCache;
    private bool _useGravityCache;

    private void Awake()
    {
        _useGravityCache = GetComponent<Rigidbody>().useGravity;

        if(CanGrab)
            transform.parent = null;
    }

    public override void AttachTo(IGrabber grabber)
    {
        transform.SetParent(grabber.transform);

        // Move this out into a compositing pattern
        if (!KeepWorldTransform)
        {
            transform.position = grabber.transform.position;
            transform.rotation = grabber.transform.rotation;
        }

        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;

        Grabber = grabber;
    }

    public override void Detatch(IGrabber grabber)
    {
        transform.parent = null;

        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;

        Grabber = null;
    }
}