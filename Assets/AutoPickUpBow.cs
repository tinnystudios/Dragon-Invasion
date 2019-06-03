using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPickUpBow : MonoBehaviour
{
    public BowHeroCharacter BowHeroCharacter;
    public Bow Bow;

    private void Awake()
    {
        BowHeroCharacter.PickUp(Bow);
    }
}
