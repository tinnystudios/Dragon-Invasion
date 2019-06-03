using System.Collections;
using UnityEngine;

public class FireDecision : Decision, IBind<Transform>
{
    public Transform Target;

    public Transform Pivot;
    public Fireball FireballPrefab;
    public CoolDown CoolDown;

    public float Power = 3;

    public void Bind(Transform dependent) => Target = dependent;

    /// <summary>
    /// Don't even consider firing if you are cooling down
    /// </summary>
    public override float Availability => CoolDown.IsCoolingDown ? 0 : 1;

    public override IEnumerator Do()
    {
        if (CoolDown.IsCoolingDown)
            yield break;

        CoolDown.Begin();

        var fireball = Instantiate(FireballPrefab, Pivot.position, Pivot.rotation);
        var velocity = Pivot.forward * Power;

        fireball.Fire(velocity);

        // Or Stun X Time before making a decision
        yield break;   
    }
}