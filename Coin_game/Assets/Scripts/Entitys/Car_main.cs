using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_main : MonoBehaviour
{
    public void Enter()
    {
        if(Game_manager_main.instance.Player_survived_the_president)
        {
            //Call event
            Events_main.instance.Player_get_in_the_car_event.Invoke();

            //Sound
            Sound_system.instance.Create_sound("Car_engine_turn_on", 1f);
        }
    }
}
