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
        if(Body.Can_move)
        {
            Move();
        }
        //Lock position
        else if(Body.Rb2d.bodyType != RigidbodyType2D.Static)
        {
            Body.Rb2d.velocity = Vector2.zero;
        }
        
        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            Flash_light();
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

    private void Interact()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 1, Vector2.zero);

        foreach(RaycastHit2D hit in hits)
        {
            switch(hit.collider.tag)
            {
                case "Galatron":
                    //Pick up
                    hit.collider.gameObject.GetComponent<Galatron_entity>().Pick_up();
                    break;

                case "Ship":
                    //Enter ship
                    hit.collider.gameObject.GetComponent<Space_ship_main>().Enter(this.gameObject);
                    break;

                case "President":
                    //Talk
                    hit.collider.gameObject.GetComponent<President_main>().Talk();
                    break;

                case "Vault":
                    //Enter vault
                    hit.collider.gameObject.GetComponent<Vault_main>().Enter();
                    break;
            }
        }
    }

    private void Flash_light()
    {
        Flash_light_obj.SetActive(!Flash_light_obj.activeSelf);

        //Sound
        Sound_system.instance.Create_sound("Flash_light_button", 1f);
    }

    #endregion
}
