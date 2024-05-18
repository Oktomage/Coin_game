using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galatron_entity : MonoBehaviour
{
    public void Pick_up()
    {
        //Call event
        Events_main.instance.Galatron_picked_up_event.Invoke();

        //Set
        Game_manager_main.instance.Player_have_galatron = true;

        //Sound
        Sound_system.instance.Create_sound("Mystery_1", 1);

        Destroy(this.gameObject);
    }
}
