using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_view_main : MonoBehaviour
{
    #region Triggers

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //View a aberration
        if(collision.CompareTag("Enemy"))
        {
            Events_main.instance.Player_view_a_aberration_event.Invoke();
        }
    }

    #endregion
}
