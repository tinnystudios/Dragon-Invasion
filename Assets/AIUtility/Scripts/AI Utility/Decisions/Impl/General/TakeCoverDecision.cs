using System.Collections;

public class TakeCoverDecision : Decision
{
    public override IEnumerator Do()
    {
        var agent = Context.Intelligence.transform;
        agent.position += -agent.forward * 2;

        yield break;
    }
}