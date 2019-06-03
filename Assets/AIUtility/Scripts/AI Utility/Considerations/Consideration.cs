using System;
using UnityEngine;

public class  Consideration : MonoBehaviour
{
    public ScorePropertyBase Property;

    public AnimationCurve Curve = AnimationCurve.Linear(0,0,1,1);
    [Range(0, 1)] public float Weight = 1;

    public float RawScore { get; set; }

    public virtual float EvaluateScore(float score)
    {
        return Curve.Evaluate(score);
    }
}

public abstract class Consideration<T> : Consideration where T : ContextProviderBase
{
    public T Provider;

    public bool Validate
    {
        get
        {
            var isMono = Type.IsSubclassOf(typeof(MonoBehaviour));

            if(isMono)
                Provider = GetComponentInParent<T>();

            return Provider != null;
        }
    }

    public Type Type => typeof(T);
}