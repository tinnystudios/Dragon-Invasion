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

        foreach (var stage in _stages)
        {
            stage.gameObject.SetActive(false);
        }

        return StartCoroutine(Run());
    }

    public IEnumerator Run()
    {
        foreach (var stage in _stages)
        {
            stage.gameObject.SetActive(true);
            yield return stage.Run();
            stage.gameObject.SetActive(false);
        }
    }
}