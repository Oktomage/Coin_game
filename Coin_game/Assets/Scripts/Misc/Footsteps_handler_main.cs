using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps_handler_main : MonoBehaviour
{
    [Header("Body")]
    public Humanoid_body Body;

    [Header("Configs")]
    [Range(0, 1f)]
    public float Footstep_delay;

    private void Start()
    {
        Configure();
    }

    #region Initial functions

    private void Configure()
    {
        //Get components
        Body = this.gameObject.GetComponent<Humanoid_body>();

        //Start routine
        StartCoroutine("Footsteps_routine");
    }

    #endregion

    #region Routine functions

    IEnumerator Footsteps_routine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Footstep_delay);

            //If moving
            if(Body.Rb2d.velocity != Vector2.zero)
            {
                //Sound
                Sound_system.instance.Create_sound("Footstep_1", 0.1f);
            }
        }
    }

    #endregion
}
