using UnityEngine;

/// <summary>
/// When the looker look near the agent, the score increases
/// </summary>
public class ScoreLookAt : ScorePropertyBase, IBind<Transform>
{
    public Transform Looker;

    public float Min = 0.9F;
    public float Max = 1.0F;

    public float MyScore;

    public void Bind(Transform dependent) => Looker = dependent;

    public override float Score(DecisionContext context)
    {
        if (Looker == null)
            return 0;

        var dir = context.Intelligence.transform.position - Looker.transform.position;
        dir.Normalize();

        var dotProductToArrow = Vector3.Dot(dir, Looker.transform.forward);
        MyScore = Mathf.InverseLerp(Min, Max, dotProductToArrow);

        return Mathf.InverseLerp(Min, Max, dotProductToArrow);
    }
}
