using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Light_fluctuation_main : MonoBehaviour
{
    [Header("Configs")]
    [Range(0f, 1f)]
    public float Fluctuation_frequency;
    [Range(0, 2f)]
    public float Falloff_intensity;

    [Header("Components")]
    public Light2D Light;

    //Internal vars
    internal float Default_intensity;

    private void Start()
    {
        Configure();
    }

    #region Initial functions

    private void Configure()
    {
        //Get components
        Light = this.gameObject.GetComponent<Light2D>();

        //Get
        Default_intensity = Light.intensity;

        //Start routine
        StartCoroutine("Fluctuation_routine");
    }

    #endregion

    #region Core functions

    IEnumerator Fluctuation_routine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Fluctuation_frequency);

            //Set
            Light.intensity = Default_intensity + Random.Range(-Falloff_intensity, Falloff_intensity);
        }
    }

    #endregion
}
