using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_main : MonoBehaviour
{
    [Header("Configs")]
    public float Cam_speed;
    public float Cam_mouse_offset_multiplier;

    [Space(10)]
    public Transform Target_transform;

    private void Update()
    {
        Move();
    }

    #region Core functions

    private void Move()
    {
        //Mouse offset
        Vector2 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = (mouse_pos - new Vector2(transform.position.x, transform.position.y)).normalized;

        Vector3 pos = new Vector3(Target_transform.position.x + dir.x * Cam_mouse_offset_multiplier, Target_transform.position.y + dir.y * Cam_mouse_offset_multiplier, -10);

        //Move
        transform.position = Vector3.Slerp(transform.position, pos, Cam_speed * Time.deltaTime);
    }

    #endregion
}
