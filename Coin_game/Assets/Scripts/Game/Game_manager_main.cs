using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_manager_main : MonoBehaviour
{
    public static Game_manager_main instance;

    [Header("Stats")]
    public string Objective_desc;

    [Header("Bools")]
    public bool Player_have_galatron;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Configure();
    }

    #region Initial functions

    private void Configure()
    {
        //Clear all listeners
        /*
        Events_main.instance.Galatron_picked_up_event.RemoveAllListeners();
        Events_main.instance.Player_get_the_ship_event.RemoveAllListeners();
        */

        //Set events listeners based on level
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level_1":
                Events_main.instance.Galatron_picked_up_event.AddListener(Spawn_temple_aberrations);
                Events_main.instance.Player_get_the_ship_event.AddListener(Spawn_ship_aberrations);

                //Set
                Objective_desc = "Roube o 'Galatron' de dentro do templo.";
                break;

            case "Level_2":

                //Set
                Objective_desc = "Converse com o presidente sobre o seu achado.";
                break;
        }
    }

    #endregion

    #region Level_1 events

    private void Spawn_temple_aberrations()
    {
        Vector2 pos = new Vector2(2, 165);
        int amount = 3;

        //Spawn it
        for(int i = 0; i < amount; i++)
        {
            Spawn_enemy(pos, Resources.Load<Enemy_scriptable>("Enemies/Aberration_level_1"));
        }

        //Next step
        Get_next_level_1_objective();
    }

    private void Get_next_level_1_objective()
    {
        Objective_desc = "Volte para a sua nave.";
    }

    private void Spawn_ship_aberrations()
    {
        GameObject plr = GameObject.FindGameObjectWithTag("Player");
        int amount = 10;

        //Spawn it
        for (int i = 0; i < amount; i++)
        {
            Vector2 pos = new Vector2(plr.transform.position.x + Random.Range(-10f, 10f) , plr.transform.position.y + Random.Range(-10f, 10f));

            Spawn_enemy(pos, Resources.Load<Enemy_scriptable>("Enemies/Aberration_level_2"));
        }

        //Sound
        Sound_system.instance.Create_sound("Souls_scream_1", 1f);

        //Change level
        StartCoroutine(Change_level(6f, 1));
    }

    #endregion

    #region Level_2 events

    #endregion

    #region External functions

    private GameObject Spawn_enemy(Vector2 pos, Enemy_scriptable enemy_scriptable)
    {
        GameObject new_enemy = Instantiate(Resources.Load("Prefabs/Humanoids/Enemy"), pos, Quaternion.identity) as GameObject;

        //Configure
        new_enemy.GetComponent<AI_main>().Configure(enemy_scriptable);

        return new_enemy;
    }

    IEnumerator Change_level(float delay, int level_id)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(level_id);
    }

    #endregion
}
