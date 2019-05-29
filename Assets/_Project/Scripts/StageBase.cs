using System.Collections;
using UnityEngine;

public abstract class StageBase : MonoBehaviour
{
    /// <summary>
    /// Run until it ends, typically a StageRunner will execute it
    /// </summary>
    /// <returns></returns>
    public abstract IEnumerator Run();
}