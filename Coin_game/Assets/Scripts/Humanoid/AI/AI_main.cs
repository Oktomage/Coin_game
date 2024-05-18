using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_main : MonoBehaviour
{
    [Header("Body")]
    public Humanoid_body Body;

    [Header("Enemy")]
    public Enemy_scriptable Enemy_class_scriptable;

    [Header("Components")]
    public List<GameObject> Arms_list;

    #region Initial functions

    public void Configure(Enemy_scriptable enemy_scriptable)
    {
        //Get
        Enemy_class_scriptable = enemy_scriptable;

        //Configure body
        Body.Configure(Enemy_class_scriptable);

        switch(Enemy_class_scriptable.Enemy_Level)
        {
            case 1:
                Arms_list[0].SetActive(true);
                break;

            case 2:
                Arms_list[0].SetActive(true);
                Arms_list[1].SetActive(true);
                break;

            case 3:
                Arms_list[0].SetActive(true);
                Arms_list[1].SetActive(true);
                Arms_list[2].SetActive(true);
                break;
        }
    }

    #endregion

    private void Update()
    {
        if(Body.Target_obj != null)
        {
            Move_towards_player();
        }
        //Lock position
        else
        {
            Body.Rb2d.velocity = Vector2.zero;
        }

        View();
    }

    #region Core functions

    private void View()
    {
        //Keep searching for the player
        if(Body.Target_obj == null)
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, Body.View_range, Vector2.zero);

            foreach(RaycastHit2D hit in hits)
            {
                //Its the player
                if(hit.collider.CompareTag("Player"))
                {
                    //Set
                    Body.Target_obj = hit.collider.gameObject;
                }
            }
        }
    }

    private void Move_towards_player()
    {
        //Get direction
        Vector2 dir = (Body.Target_obj.transform.position - transform.position).normalized;

        //Move
        Body.Rb2d.velocity = dir * Body.Move_speed;
    }

    private void Attack()
    {

    }

    #endregion
}
