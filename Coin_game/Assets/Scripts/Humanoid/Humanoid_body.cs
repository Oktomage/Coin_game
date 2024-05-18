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
    public float View_range;

    [Header("Bools")]
    public bool Can_move;
    public bool Can_attack;

    //Consts
    public const float MAX_MOVE_SPEED = 10;

    //Internal vars
    internal SpriteRenderer Render;
    internal Rigidbody2D Rb2d;

    internal GameObject Health_bar_obj;
    internal GameObject Target_obj;

    #region Initial functions

    private void Get_components()
    {
        Render = this.gameObject.GetComponent<SpriteRenderer>();
        Rb2d = this.gameObject.GetComponent<Rigidbody2D>();

        Health_bar_obj = Create_health_bar();
    }

    private void Set_initial_humanoid_state()
    {
        //Set
        Can_move = true;
        Can_attack = true;
    }

    public void Configure(float hlth, float dmg, float mv_spd, float atck_spd, float atck_rng)
    {
        Get_components();

        //Set
        Max_health = hlth;
        Health = Max_health;

        Damage = dmg;
        
        Move_speed = (MAX_MOVE_SPEED * mv_spd);
        
        Attack_speed = atck_spd;
        Attack_range = atck_rng;

        Set_initial_humanoid_state();
    }

    public void Configure(Enemy_scriptable enemy)
    {
        Get_components();

        //Get
        Max_health = enemy.Enemy_Health;
        Health = Max_health;

        Damage = enemy.Enemy_Damage;

        Move_speed = (MAX_MOVE_SPEED * enemy.Enemy_Move_speed);

        Attack_speed = enemy.Enemy_Attack_speed;
        Attack_range = enemy.Enemy_Attack_range;
        View_range = enemy.Enemy_View_range;

        //Set
        transform.localScale *= enemy.Enemy_Size_multiplier;

        Set_initial_humanoid_state();
    }

    private GameObject Create_health_bar()
    {
        //Create it
        float y_offset = 1.5f * transform.localScale.y;
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + y_offset, transform.position.z);
        GameObject health_bar = Instantiate(Resources.Load("Prefabs/Entitys/Health_bar"), pos, Quaternion.identity) as GameObject;

        //Set parent
        health_bar.transform.SetParent(this.transform);

        return health_bar;
    }

    #endregion

    #region Core functions

    public IEnumerator Attack_cooldown()
    {
        Can_attack = false;

        yield return new WaitForSeconds(Attack_speed);

        Can_attack = true;
    }

    #endregion
}
