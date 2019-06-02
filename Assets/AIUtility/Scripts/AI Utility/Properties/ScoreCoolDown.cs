public class ScoreCoolDown : ScorePropertyBase
{
    public CoolDown CoolDown;

    public override float Score(DecisionContext context)
    {
        return CoolDown.IsCoolingDown ? 0 : 1;
    }
}

// If you are cooling down          : 1
// If you are not cooling down      : 0

