using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intelligence : MonoBehaviour
{
    private DecisionContext _decisionContext;
    private DecisionMaker _decisionMaker = new DecisionMaker();

    public Decision SelectedDecision { get; private set; }
    public List<Decision> Decisions { get; } = new List<Decision>();

    public float Weight = 0.2F;

    private void Awake()
    {
        _decisionContext = new DecisionContext
        {
            Intelligence = this,
        };

        GetComponentsInChildren(Decisions);
        StartCoroutine(Run());
    }

    private IEnumerator Run()
    {
        while (true)
        {
            SelectedDecision = _decisionMaker.ScoreAllDecisions(_decisionContext, Decisions);

            if (SelectedDecision.Score > Weight)
                yield return SelectedDecision.Do();
            else
                yield return null;
        }
    }
}