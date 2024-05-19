using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space_ship_main : MonoBehaviour
{
    [Header("Components")]
    public GameObject Rocket_engine_particle;

    #region Core functions

    public void Enter(GameObject plr_obj)
    {
        //If player have galatron, get in 
        if(Game_manager_main.instance.Player_have_galatron)
        {
            //Call event
            Events_main.instance.Player_get_the_ship_event.Invoke();

            //Disable plr controls
            plr_obj.GetComponent<Humanoid_body>().Can_move = false;

            plr_obj.GetComponent<Humanoid_body>().Capsule_coll.enabled = false;
            plr_obj.GetComponent<Humanoid_body>().Rb2d.bodyType = RigidbodyType2D.Static;

            //Set plr as a ship parent
            plr_obj.transform.position = this.gameObject.transform.position;

            plr_obj.transform.SetParent(this.gameObject.transform);

            Start_engine();
        }
    }

    private void Start_engine()
    {
        //Sound
        Sound_system.instance.Create_sound("Rocket_engine", 1f);

        //Particles
        Rocket_engine_particle.SetActive(true);
    }

    #endregion
}
