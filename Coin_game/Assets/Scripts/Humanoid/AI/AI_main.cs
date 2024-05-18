using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_main : MonoBehaviour
{
    [Header("Body")]
    public Humanoid_body Body;

    [Header("Enemy")]
    public Enemy_scriptable Enemy_class_scriptable;

    #region Initial functions

    public void Configure()
    {
        //Configure body
        Body.Configure(Enemy_class_scriptable);
    }

    #endregion

    private void Update()
    {
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

    }

    private void Attack()
    {

    }

    #endregion
}
