using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class President_main : MonoBehaviour
{
    [Header("Configs")]
    public List<string> Talk_txt = new List<string>();

    [Header("Bools")]
    public bool Can_talk;

    private void Start()
    {
        //Add event listener
        Events_main.instance.Player_gave_the_coin_to_president_event.AddListener(Turn_into_monster);
    }

    #region Core functions

    public void Talk()
    {
        if (Can_talk)
        {
            //Set
            Can_talk = false;

            Game_manager_main.instance.Player_talked_to_president = true;

            //Open dialog
            Dialog_system.instance.Request_text(Talk_txt);
        }
    }

    private void Turn_into_monster()
    {
        //Create new enemy
        GameObject enemy = Instantiate(Resources.Load("Prefabs/Humanoids/Enemy"), transform.position, Quaternion.identity) as GameObject;

        //Configure
        enemy.GetComponent<AI_main>().Configure(Resources.Load<Enemy_scriptable>("Enemies/Aberration_level_1"));

        //Sound
        Sound_system.instance.Create_sound("Blood_splash", 0.4f);
        Sound_system.instance.Create_sound("Monster_scream", 1);

        //Particles
        Instantiate(Resources.Load("Prefabs/Entitys/Big_blood"), transform.position, Quaternion.identity);

        //Destroy president
        Destroy(this.gameObject);
    }

    #endregion
}
