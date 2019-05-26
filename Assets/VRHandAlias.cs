using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHandAlias : MonoBehaviour
{
    public Transform RealHand;

    private void Update()
    {
        if (Application.isEditor)
            return;

        transform.position = RealHand.position;
        transform.rotation = RealHand.rotation;
    }
}
