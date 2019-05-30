using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRSimulator : MonoBehaviour
{
    public VRHandAlias LeftHand;
    public VRHandAlias RightHand;

#if UNITY_EDITOR
    private void Update()
    {
        LeftHand.transform.position += GameInput.Movement * Time.deltaTime * 3;
    }
#endif
}
