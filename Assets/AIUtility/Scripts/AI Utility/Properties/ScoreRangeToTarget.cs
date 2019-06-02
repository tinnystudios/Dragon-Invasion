using UnityEngine;

public class ScoreRangeToTarget : ScorePropertyBase
{
    public Transform Target;

    [Header("Range")]
    public float Min = 0;
    public float Max = 1;

    [Header("Gizmos")]
    public Color Color;

    public override float Score(DecisionContext context)
    {
        if (Target == null)
            return 0;

        var dist = Vector3.Distance(context.Intelligence.transform.position, Target.position);
        return Mathf.InverseLerp(Min, Max, dist);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color;
        Gizmos.DrawWireSphere(transform.position, Min);
        Gizmos.DrawWireSphere(transform.position, Max);
    }
}
