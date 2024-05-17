using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_bar_main : MonoBehaviour
{
    [Header("Body")]
    public Humanoid_body Body;

    [Header("Stats")]
    [Range(0, 1f)]
    public float Bar_value;

    [Header("Components")]
    public GameObject Bar_obj;

    public void Configure(Humanoid_body body)
    {
        Body = body;

        StartCoroutine("Update_bar_value");
    }

    IEnumerator Update_bar_value()
    {
        while(true) {
            yield return new WaitForSeconds(0.1f);

            //Update value
            Bar_value = Body.Health / Body.Max_health;

            //Set
            Bar_obj.transform.localScale = new Vector3(Bar_value * 2, Bar_obj.transform.localScale.y, 1);
        }
    }
}
