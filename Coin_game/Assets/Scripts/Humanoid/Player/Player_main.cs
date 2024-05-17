using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_main : MonoBehaviour
{
    [Header("Body")]
    public Humanoid_body Body;

    public void Configure()
    {
        //Configure body
        Body.Configure(20, 1, 0.8f, 1, 1);
    }

    private void Update()
    {
        
    }

    private void Move()
    {

    }
}
