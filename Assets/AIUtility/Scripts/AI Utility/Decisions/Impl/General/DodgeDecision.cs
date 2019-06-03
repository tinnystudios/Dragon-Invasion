using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeDecision : Decision
{
    public float Distance = 1;

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
        var duration = 0.5F;
        var startPosition = agent.transform.position;

        for (float i = 0; i < 1.0F; i += Time.deltaTime / duration)
        {
            agent.transform.position = Vector3.Lerp(startPosition, dodgeTo, i);
            yield return null;
        }
    }
}