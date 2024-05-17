using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_main : MonoBehaviour
{
    [Header("Configs")]
    public float Cam_speed;

    [Space(10)]
    public Transform Target_transform;

    private void Update()
    {
        Move();
    }

    #region Core functions

    private void Move()
    {
        transform.position = Vector3.Slerp(transform.position, new Vector3(Target_transform.position.x, Target_transform.position.y, transform.position.z), Cam_speed * Time.deltaTime);
    }

    #endregion
}
