using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy")]
public class Enemy_scriptable : ScriptableObject
{
    [Header("Stats")]
    public string Enemy_Name;
    public int Enemy_Level;
    public float Enemy_Health;
    public float Enemy_Size_multiplier;

    [Space(10)]
    public float Enemy_Damage;

    [Space(10)]
    [Range(0f, 1f)]
    public float Enemy_Move_speed;
    public float Enemy_Attack_speed;
    public float Enemy_Attack_range;
    public float Enemy_View_range;
}
