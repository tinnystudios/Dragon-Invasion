using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeDecision : Decision
{
    public float Distance = 1;
    public float Duration = 0.5F;

    [Range(0,100)]
    public int DodgeChance = 10;
    public CoolDown CoolDown;

    public override IEnumerator Do()
    {
        if (CoolDown.IsCoolingDown)
            yield break;

        CoolDown.Begin();

        var canDodge = Random.Range(0, 100) <= DodgeChance;

        if (!canDodge)
            yield break;

        var agent = Context.Intelligence;

        var dir = Random.onUnitSphere;

        var dodgeTo = agent.transform.position + dir * Distance;
        var startPosition = agent.transform.position;

        for (float i = 0; i < 1.0F; i += Time.deltaTime / Duration)
        {
            agent.transform.position = Vector3.Lerp(startPosition, dodgeTo, i);
            yield return null;
        }
    }
}