using System.Collections;
using UnityEngine;

/// <summary>
/// A top level manager to run children stages
/// </summary>
public class StageRunner : MonoBehaviour
{
    private StageBase[] _stages;

    public Coroutine Begin()
    {
        _stages = GetComponentsInChildren<StageBase>();
        return StartCoroutine(Run());
    }

    public IEnumerator Run()
    {
        foreach (var stage in _stages)
        {
            yield return stage.Run();
        }
    }
}