using System.Collections;
using UnityEngine;

/// <summary>
/// The root of the application
/// </summary>
public class App : MonoBehaviour, IBind<StageRunner>
{
    private StageRunner _stageRunner;
    public void Bind(StageRunner dependent) => _stageRunner = dependent;

    /// <summary>
    /// The end of this coroutine signifies the end of the application
    /// </summary>
    /// <returns></returns>
    private IEnumerator Start()
    {
        var dataBinder = gameObject.AddComponent<AppDataBinder>();
        dataBinder.Bind();

        yield return _stageRunner.Begin();
    }
}