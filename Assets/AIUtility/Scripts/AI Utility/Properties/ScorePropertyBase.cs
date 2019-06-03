using UnityEngine;

/// <summary>
/// A base class for scoring a property of a decision
/// </summary>
public abstract class ScorePropertyBase : MonoBehaviour
{
    /// <summary>
    /// Returns a Score from 0-1 where 0 is least desirable and 1 is most desirable
    /// </summary>
    /// <returns></returns>
    public abstract float Score(DecisionContext context);
}

public abstract class ScorePropertyBase<T> : ScorePropertyBase
{

}