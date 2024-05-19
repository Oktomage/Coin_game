using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Map3_final_event_trigger : MonoBehaviour
{
    #region Triggers

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Trigger_event();
        }
    }

    #endregion

    #region Core functions

    private void Trigger_event()
    {
        if(Game_manager_main.instance.Player_talked_to_survivor)
        {
            //Call event
            Events_main.instance.Player_get_out_survivor_house_event.Invoke();
        }
    }

    #endregion
}
