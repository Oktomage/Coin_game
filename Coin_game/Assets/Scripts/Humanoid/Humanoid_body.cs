using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humanoid_body : MonoBehaviour
{
    [Header("Stats")]
    public float Health;
    public float Max_health;

    [Space(10)]
    public float Damage;

    [Space(10)]
    public float Move_speed;
    public float Attack_speed;
    public float Attack_range;

    //Consts
    public const float MAX_MOVE_SPEED = 10;

    //Internal vars
    internal SpriteRenderer Render;
    internal Rigidbody2D Rb2d;

    #region Initial functions

    private void Get_components()
    {
        Render = this.gameObject.GetComponent<SpriteRenderer>();
        Rb2d = this.gameObject.GetComponent<Rigidbody2D>();
    }

    public void Configure(float hlth, float dmg, float mv_spd, float atck_spd, float atck_rng)
    {
        Get_components();
    }

    public void Configure(Enemy_scriptable enemy)
    {
        Get_components();
    }

    #endregion
}
