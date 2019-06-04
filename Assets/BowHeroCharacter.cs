using System;
using UnityEngine;

/// <summary>
/// The main event broadcaster 
/// </summary>
public class BowHeroCharacter : MonoBehaviour
{
    public Grabber LeftHand;
    public Grabber RightHand;

    public Bow Bow { get; private set; }

    public event Action<Bow> OnBowPickedUp;
    public event Action<Arrow> OnArrowFired;

    private void Awake()
    {
        LeftHand.OnGrabAttach += OnGrab;
        RightHand.OnGrabAttach += OnGrab;
    }

    private void OnDestroy()
    {
        LeftHand.OnGrabAttach -= OnGrab;
        RightHand.OnGrabAttach -= OnGrab;
    }

    private void OnGrab(IGrabbable obj)
    {
        var bow = obj.transform.GetComponent<Bow>();
        if (bow != null)
        {
            PickUp(bow);
        }
    }

    public void PickUp(Bow bow)
    {
        Bow = bow;
        OnBowPickedUp?.Invoke(bow);
    }

    public void FireArrow(Arrow arrow)
    {
        OnArrowFired?.Invoke(arrow);
    }
}