using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events_main : MonoBehaviour
{
    public static Events_main instance;

    //Events
    public UnityEvent Galatron_picked_up_event;

    private void Awake()
    {
        instance = this;   
    }
}
