using System.Collections;
using UnityEngine;

public class CoolDown : MonoBehaviour
{
    public float MinDuration = 0.5F;
    public float MaxDuration = 2.0F;

    public bool IsCoolingDown { get; private set; }
    
    public Coroutine Begin()
    {
        return StartCoroutine(Run());
    }

    private IEnumerator Run()
    {
        var duration = Random.Range(MinDuration, MaxDuration);

        IsCoolingDown = true;
        yield return new WaitForSeconds(duration);
        IsCoolingDown = false;
    }
}