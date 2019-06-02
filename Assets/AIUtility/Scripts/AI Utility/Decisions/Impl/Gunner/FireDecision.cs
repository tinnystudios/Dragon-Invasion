using System.Collections;
using UnityEngine;

public class FireDecision : Decision
{
    public Transform Target;

    public override IEnumerator Do()
    {
        yield return new WaitForSeconds(0.2F);
    }
}