using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player_main : MonoBehaviour
{
    [Header("Body")]
    public Humanoid_body Body;

    [Header("Components")]
    public GameObject Flash_light_obj;

    private void Start()
    {
        Configure();
    }

    #region Initial functions

    public void Configure()
    {
        //Configure body
        Body.Configure(20, 1, 0.5f, 1, 1);
    }

    #endregion

    private void Update()
    {
        Move();
        
        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    #region Core functions

    private void Move()
    {
        //Apply velocity to rigid body
        Body.Rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * Body.Move_speed, Input.GetAxisRaw("Vertical") * Body.Move_speed);

        //Flash point to cursos
        Vector2 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mouse_pos - new Vector2(transform.position.x, transform.position.y);

        Flash_light_obj.transform.up = dir;
    }

    private void Attack()
    {
        if(Body.Can_attack)
        {

            //Start cooldown
            Body.StartCoroutine("Attack_cooldown");
        }
    }

    #endregion
}
