using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_manager_main : MonoBehaviour
{
    public static Game_manager_main instance;

    [Header("Stats")]
    public string Objective_desc;

    //Internal vars
    internal bool Player_have_galatron;
    internal bool Player_talked_to_president;
    internal bool Player_survived_the_president;
    internal bool Player_talked_to_survivor;

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
        //Set events listeners based on level
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level_1":
                Events_main.instance.Galatron_picked_up_event.AddListener(Spawn_temple_aberrations);
                Events_main.instance.Player_get_the_ship_event.AddListener(Spawn_ship_aberrations);

                //Set
                Day_cycle_system.instance.Set_day_time(0);

                Objective_desc = "Roube o 'Galatron' de dentro do templo.";
                break;

            case "Level_2":
                Events_main.instance.Player_gave_the_coin_to_president_event.AddListener(Get_next_level_2_objective);
                Events_main.instance.Player_get_in_the_president_vaults_event.AddListener(Player_got_in_the_vault);
                Events_main.instance.Player_get_out_the_vaults_event.AddListener (Get_next_level_2_objective_2);
                Events_main.instance.Player_get_in_the_car_event.AddListener(Player_got_in_the_car);

                //Set
                Player_have_galatron = true;

                Day_cycle_system.instance.Set_day_time(1);

                Objective_desc = "Converse com o presidente sobre o seu achado.";
                break;

            case "Level_3":
                Events_main.instance.Survivor_died_event.AddListener(Get_next_level_3_objective);
                Events_main.instance.Survivor_died_event.AddListener(Spawn_aberrations_outside);

                //Set
                Player_have_galatron = true;

                Day_cycle_system.instance.Set_day_time(0);

                Objective_desc = "Tente achar alguém vivo.";
                break;
        }
    }

    #endregion

    #region Level_1 events

    private void Spawn_temple_aberrations()
    {
        Vector2 pos = new Vector2(2, 165);
        int amount = 1;

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

    private void Get_next_level_2_objective()
    {
        Objective_desc = "Corra para o vault do presidente (Fica ao lado do lago na frente da casa dele).";
    }

    private void Player_got_in_the_vault()
    {
        //Clear all enemies
        GameObject[] All_enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in All_enemies)
        {
            Destroy(enemy);
        }

        //Set
        Day_cycle_system.instance.Set_day_time(0.4f);

        //Call black screen
        UI_manager.instance.StartCoroutine(UI_manager.instance.Show_black_screen(5f, "14 horas depois..."));

        //Call event
        Events_main.instance.Player_get_out_the_vaults_event.Invoke();
    }

    private void Get_next_level_2_objective_2()
    {
        Objective_desc = "Pegue seu carro é vá até a cidade.";
    }

    private void Player_got_in_the_car()
    {
        //Call black screen
        UI_manager.instance.StartCoroutine(UI_manager.instance.Show_black_screen(10f, ""));

        //Change level
        StartCoroutine(Change_level(6f, 2));
    }

    #endregion

    #region Level 3_events

    private void Get_next_level_3_objective()
    {
        Objective_desc = "???";
    }

    private void Spawn_aberrations_outside()
    {

    }

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
