using System.Collections;
using UnityEngine;

public abstract class StageBase : MonoBehaviour
{
    public abstract IEnumerator Run();
}