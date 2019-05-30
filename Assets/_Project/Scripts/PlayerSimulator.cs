using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSimulator : MonoBehaviour
{
    public Transform Player;
    public Arrow Arrow;

    public float MoveSpeed = 1;

#if UNITY_EDITOR
    private void Update()
    {
        Player.transform.position += GameInput.Movement * MoveSpeed;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

        if (Input.GetButtonDown("Fire1"))
        {
            var pos = Vector3.zero + ray.direction * 1;
            var arrow = Instantiate(Arrow, ray.origin, transform.rotation);
            arrow.transform.LookAt(pos);
            arrow.Fire(10);
        }

    }
#endif
}
