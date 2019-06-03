using System;
using UnityEngine;

public class BowHeroCharacter : MonoBehaviour
{
    public Bow Bow { get; private set; }

    public event Action<Bow> OnBowPickedUp;
    public event Action<Arrow> OnArrowFired;

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
