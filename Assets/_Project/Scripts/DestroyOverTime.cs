using System.Collections;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    private float Lifetime = 2.0F;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}