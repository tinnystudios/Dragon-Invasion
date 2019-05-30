using System;
using UnityEngine;

public class GrabberInput
{
    public Action OnGrabDown;
    public Action OnGrabUp;
    public Action OnGrab;

    public bool IsGrabbing(EHandedness hand)
    {
        switch (hand)
        {
            case EHandedness.Left:
                return Input.GetKey(KeyCode.G) ||
                    OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) != 0 ||
                    OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) != 0;

            case EHandedness.Right:
                return Input.GetKey(KeyCode.B) ||
                    OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) != 0 ||
                    OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) != 0;
            default:
                return false;
        }
    }

    public bool IsGrabUp(EHandedness hand)
    {
        var state = false;

        switch (hand)
        {
            case EHandedness.Left:
                state =
                    Input.GetKeyUp(KeyCode.G) ||
                    OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger) ||
                    OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger);
                break;
            case EHandedness.Right:
                state = 
                    Input.GetKeyUp(KeyCode.B) ||
                    OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger) ||
                    OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger);
                break;
        }

        if (state)
        {
            OnGrabUp?.Invoke();
        }

        return state;
    }
}

public enum EHandedness
{
    Left,
    Right,
    All
}
