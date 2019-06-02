using System.Collections;
using UnityEngine;

public class MoveToDecision : Decision, IBind<Transform>
{
    public Transform Target;

    public float MoveSpeed = 5;

    public void Bind(Transform dependent) => Target = dependent;

    public override IEnumerator Do()
    {
        var agent = Context.Intelligence;
        var dir = Target.position - agent.transform.position;
        dir.Normalize();

        agent.transform.LookAt(Target);
        agent.transform.position += dir * MoveSpeed * Time.deltaTime;
        yield break;
    }
}
