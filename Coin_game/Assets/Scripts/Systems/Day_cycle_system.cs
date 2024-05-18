using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Day_cycle_system : MonoBehaviour
{
    public static Day_cycle_system instance;

    [Header("Configs")]
    [Range(0, 1f)]
    public float Day_value;

    [Header("Components")]
    public Light2D Sun_light;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Configure();
    }

    #region Intial functions

    private void Configure()
    {

    }

    #endregion

    #region Core functions

    public void Set_day_time(float value)
    {
        //Get
        Day_value = Mathf.Clamp01(value);

        //Set to sun
        Sun_light.intensity = Day_value;
    }

    #endregion
}
