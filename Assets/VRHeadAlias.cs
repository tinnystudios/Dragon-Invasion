using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHeadAlias : MonoBehaviour
{
    public Transform Head;

    // Update is called once per frame
    void Update()
    {
        transform.position = Head.position;
    }
}
