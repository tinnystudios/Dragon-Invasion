using System.Collections;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float Lifetime = 2.0F;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(Lifetime);
        Destroy(gameObject);
    }
}