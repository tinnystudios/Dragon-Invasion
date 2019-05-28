using UnityEngine;

public static class GameInput
{
    public static Vector3 Movement => new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
}