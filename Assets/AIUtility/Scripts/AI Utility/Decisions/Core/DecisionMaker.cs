using System.Collections.Generic;
using System.Linq;

public class DecisionMaker
{
    public Decision ScoreAllDecisions(DecisionContext context, List<Decision> decisions)
    {
        var cutoff = 0.0F;

        foreach (var decision in decisions)
        {
            decision.Context = context;
            decision.Score = decision.DSE.Score(context, decision.Considerations, decision.Bonus, cutoff);

            if (decision.Score > cutoff)
                cutoff = decision.Score;
        }

        return decisions.OrderByDescending(x => x.Score).First();
    }
}