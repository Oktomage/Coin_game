using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_scare_system : MonoBehaviour
{
    [Header("Configs")]
    public bool Active;
    [Range(0, 60)]
    public float Jump_scare_delay;

    //Internal vars
    internal bool Can_jump_scare;

    private void Start()
    {
        Configure();
    }

    #region Initial functions

    private void Configure()
    {
        //Add event listeners
        Events_main.instance.Player_view_a_aberration_event.AddListener(Jump_scare);

        //Set
        Can_jump_scare = true;
    }

    #endregion

    #region Core functions

    public void Jump_scare()
    {
        if(Can_jump_scare)
        {
            //Sound
            Sound_system.instance.Create_sound("Jump_scare_2", 1);

            //Start cooldown
            StartCoroutine("Jump_scare_cooldown");
        }
    }

    IEnumerator Jump_scare_cooldown() 
    {
        Can_jump_scare = false;

        yield return new WaitForSeconds(Jump_scare_delay);

        Can_jump_scare = true;
    }

    #endregion
}
