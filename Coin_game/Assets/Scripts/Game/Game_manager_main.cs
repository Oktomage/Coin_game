using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_manager_main : MonoBehaviour
{
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

        }
    }

    #endregion
}
