using System.Collections;
using UnityEngine;

public class DodgeDecision : Decision
{
    public override IEnumerator Do()
    {
        var agent = Context.Intelligence;

        var dodgeTo = agent.transform.position + agent.transform.right * 4;
        var duration = 0.5F;
        var startPosition = agent.transform.position;

        for (float i = 0; i < 1.0F; i += Time.deltaTime / duration)
        {
            agent.transform.position = Vector3.Lerp(startPosition, dodgeTo, i);
            yield return null;
        }
    }
}