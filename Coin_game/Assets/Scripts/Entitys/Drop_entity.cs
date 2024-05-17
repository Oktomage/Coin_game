using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_entity : MonoBehaviour
{
    [Header("Configs")]
    public float Speed;
    public float Time_to_collide;

    public void Configure(float spd)
    {
        //Get
        Speed = spd;

        //Set
        Time_to_collide = Random.Range(0f, 3f);
    }

    void Update()
    {
        //Move
        transform.Translate(0, -Speed * Time.deltaTime, 0);

        //Decay timer
        Time_to_collide -= 1 * Time.deltaTime;

        if(Time_to_collide <= 0)
        {
            Impact();
        }
    }

    private void Impact()
    {
        Destroy(this.gameObject);
    }
}
