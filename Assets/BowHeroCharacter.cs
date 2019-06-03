using System;
using UnityEngine;

public class BowHeroCharacter : MonoBehaviour
{
    public Bow Bow { get; private set; }
    public event Action<Bow> OnBowPickedUp;

    public void PickUp(Bow bow)
    {
        Bow = bow;
        OnBowPickedUp?.Invoke(bow);
    }
}
