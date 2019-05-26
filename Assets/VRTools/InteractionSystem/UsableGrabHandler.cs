using System;
using UnityEngine;

public class UsableGrabHandler : BasicGrabHandler
{
    public HandPlacement LeftHandPlacement;
    public HandPlacement RightHandPlacement;

    public override bool CanDetatch => false;

    public override void AttachTo(IGrabber grabber)
    {
        base.AttachTo(grabber);

        var placement = grabber.Hand == EHandedness.Left ? LeftHandPlacement : RightHandPlacement;
        transform.localEulerAngles = placement.LocalEuler;

        transform.position = grabber.transform.position;

        grabber.OnRelease += Use;
    }

    private void Use()
    {
        // Use the item
    }
}

[Serializable]
public class HandPlacement
{
    public Vector3 LocalEuler;
    public EHandedness Handedness;
}