using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRSimulator : MonoBehaviour
{
    public VRHandAlias LeftHand;
    public VRHandAlias RightHand;

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var delta = new Vector3(horizontal, vertical, 0);

        LeftHand.transform.position += delta * Time.deltaTime * 3;
    }
}
