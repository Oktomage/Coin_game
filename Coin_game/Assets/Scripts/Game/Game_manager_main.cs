using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_manager_main : MonoBehaviour
{
    public static Game_manager_main instance;

    [Header("Stats")]
    public string Objective_desc;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Configure();
    }

    private void OnLevelWasLoaded(int level)
    {
        Configure();
    }

    #region Initial functions

    private void Configure()
    {
        //Clear all listeners
        Events_main.instance.Galatron_picked_up_event.RemoveAllListeners();

        //Set event listeners
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level_1":
                Events_main.instance.Galatron_picked_up_event.AddListener(Spawn_temple_aberrations);

                Objective_desc = "Roube o 'Galatron' de dentro do templo.";
                break;
        }
    }

    #endregion

    #region Level_1 events

    private void Spawn_temple_aberrations()
    {
        Vector2 pos = new Vector2(2, 150);
        int amount = 3;

        //Spawn it
        for(int i = 0; i < amount; i++)
        {
            Spawn_enemy(pos, Resources.Load<Enemy_scriptable>("Enemies/Aberration_level_3"));
        }

        //Next step
        Get_next_level_1_objective();
    }

    private void Get_next_level_1_objective()
    {
        Objective_desc = "Volte para a sua nave.";
    }

    #endregion

    #region Level_2 events

    #endregion

    private GameObject Spawn_enemy(Vector2 pos, Enemy_scriptable enemy_scriptable)
    {
        GameObject new_enemy = Instantiate(Resources.Load("Prefabs/Humanoids/Enemy"), pos, Quaternion.identity) as GameObject;

        //Configure
        new_enemy.GetComponent<Humanoid_body>().Configure(enemy_scriptable);

        return new_enemy;
    }
}
