using UnityEngine;

public class ScoreThreat : ScorePropertyBase
{
    [Range(0,1)]
    public float MyScore;

    public override float Score(DecisionContext context)
    {
        return MyScore;
    }
}