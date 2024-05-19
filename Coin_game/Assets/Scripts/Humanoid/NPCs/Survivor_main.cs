using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survivor_main : MonoBehaviour
{
    [Header("Configs")]
    public List<string> Talk_txt = new List<string>();

    [Header("Bools")]
    public bool Can_talk;

    private void Start()
    {
        //Set
        Can_talk = true;

        //Add event listener
        Events_main.instance.Dialog_ended_event.AddListener(Die);
    }

    #region Core functions

    public void Talk()
    {
        if (Can_talk)
        {
            //Set
            Can_talk = false;

            Game_manager_main.instance.Player_talked_to_survivor = true;

            //Open dialog
            Dialog_system.instance.Request_text(Talk_txt);
        }
    }

    private void Die()
    {
        //Disable sound
        this.gameObject.GetComponentInChildren<AudioSource>().enabled = false;

        //Call event
        Events_main.instance.Survivor_died_event.Invoke();
    }

    #endregion
}
