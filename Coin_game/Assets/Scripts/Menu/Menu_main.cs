using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_main : MonoBehaviour
{
    //Internal vars
    internal bool Changing_scene;

    #region Core functions

    public void Play_button()
    {
        if(Changing_scene == false)
        {
            //Fade in
            Black_screen_manager.instance.Show_black_screen();

            //Change level
            StartCoroutine(Change_level(2f, 1));
        }
    }

    public void Quit_button()
    {
        Application.Quit();
    }

    #endregion

    #region External tools

    IEnumerator Change_level(float delay, int level_id)
    {
        Changing_scene = true;

        yield return new WaitForSeconds(delay);

        //Load new level
        SceneManager.LoadScene(level_id);
    }

    #endregion
}
