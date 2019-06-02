using System.Collections.Generic;
using UnityEngine;

public class DecisionScoreEvaluator
{
    public float Score(DecisionContext context, List<Consideration> considerations, float bonus, float min)
    {
        var finalScore = bonus;

        foreach (var consideration in considerations)
        {
            // TODO: Include again, but this blocks the debugger
            /*
            if (finalScore <= 0 || finalScore <= min)
                break;
            */

            var rawScore = consideration.Property.Score(context);
            var response = consideration.EvaluateScore(rawScore);

            consideration.RawScore = rawScore;
            finalScore *= Mathf.Clamp(response, 0, 1);
        }

        return finalScore;
    }
}