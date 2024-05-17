using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_main : MonoBehaviour
{
    [Header("Body")]
    public Humanoid_body Body;

    [Header("Enemy")]
    public Enemy_scriptable Enemy_class_scriptable;

    #region Initial functions

    public void Configure()
    {
        //Configure body
        Body.Configure(Enemy_class_scriptable);
    }

    #endregion
}
