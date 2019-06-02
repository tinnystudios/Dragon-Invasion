using System.Collections;
using UnityEngine;

public class MoveToDecision : Decision
{
    public Transform Target;

    public float MoveSpeed = 5;

    public override IEnumerator Do()
    {
        var agent = Context.Intelligence;
        var dir = Target.position - agent.transform.position;
        dir.Normalize();

        agent.transform.position += dir * MoveSpeed * Time.deltaTime;
        yield break;
    }
}