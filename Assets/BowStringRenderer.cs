using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowStringRenderer : MonoBehaviour
{
    public Bow Bow;

    public Transform Bottom;
    public Transform Top;

    public LineRenderer LineRenderer;
    private Vector3[] positions = new Vector3[3];

    // Update is called once per frame
    void Update()
    {
        LineRenderer.positionCount = 3;
        positions[0] = Bottom.position;
        positions[1] = Bow.CanLockArrow ? Bow.ArrowPosition() : Top.position;
        positions[2] = Top.position;

        LineRenderer.SetPositions(positions);
    }
}
