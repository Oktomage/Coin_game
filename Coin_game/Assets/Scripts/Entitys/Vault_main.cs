using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vault_main : MonoBehaviour
{
    public void Enter()
    {
        if(Game_manager_main.instance.Player_talked_to_president && Game_manager_main.instance.Player_survived_the_president == false)
        {
            //Set
            Game_manager_main.instance.Player_survived_the_president = true;

            //Sound
            Sound_system.instance.Create_sound("Vault_door", 0.7f);

            //Call event
            Events_main.instance.Player_get_in_the_president_vaults_event.Invoke();
        }
    }
}
