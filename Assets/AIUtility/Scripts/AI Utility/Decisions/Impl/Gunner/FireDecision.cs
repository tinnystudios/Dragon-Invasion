using System.Collections;
using UnityEngine;

public class FireDecision : Decision
{
    public Transform Target;

    public Transform Pivot;
    public Fireball FireballPrefab;
    public CoolDown CoolDown;

    public float Power = 3;

    public override IEnumerator Do()
    {
        var fireball = Instantiate(FireballPrefab, Pivot.position, Pivot.rotation);
        var velocity = Pivot.forward * Power;

        fireball.Fire(velocity);

        yield return CoolDown.Begin();
    }
}