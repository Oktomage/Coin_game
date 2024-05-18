using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events_main : MonoBehaviour
{
    public static Events_main instance;

    //Events
    public UnityEvent Dialog_ended_event;
    public UnityEvent Galatron_picked_up_event;
    public UnityEvent Player_view_a_aberration_event;
    public UnityEvent Player_get_the_ship_event;
    public UnityEvent Player_gave_the_coin_to_president_event;
    public UnityEvent Player_get_in_the_president_vaults_event;
    public UnityEvent Player_get_out_the_vaults_event;
    public UnityEvent Player_get_in_the_car_event;

    private void Awake()
    {
        instance = this;   
    }
}
