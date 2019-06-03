﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decision : MonoBehaviour
{
    public List<Consideration> Considerations;

    [Header("Configurations")]
    [Range(0,5)]
    public float Weight = 1;

    public DecisionScoreEvaluator DSE = new DecisionScoreEvaluator();
    public DecisionContext Context { get; set; }

    /// <summary>
    /// Where 1 means the score will remain the same and 0 means the score will always be 0
    /// </summary>
    public virtual float Availability => 1.0F;

    public float Score { get; set; }
    public float Bonus => Weight;

    public abstract IEnumerator Do();
}

public abstract class Decision<T> : Decision where T : ContextProviderBase, IContextProvider
{
    public T Provider;

    public bool Validate
    {
        get
        {
            var isMono = Type.IsSubclassOf(typeof(MonoBehaviour));

            if (isMono)
                Provider = GetComponentInParent<T>();

            return Provider != null;
        }
    }

    public Type Type => typeof(T);
}