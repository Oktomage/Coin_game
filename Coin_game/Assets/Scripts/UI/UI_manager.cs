using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_manager : MonoBehaviour
{
    public static UI_manager instance;

    [Header("Components")]
    public TextMeshProUGUI TObjective;
    public GameObject PDecision;

    [Space(10)]
    public GameObject PBlack_sreen;
    public TextMeshProUGUI TBlack_screen_message;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Configure();
    }

    private void Configure()
    {
        //Set events listeners based on level
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level_2":
                //Set
                Events_main.instance.Dialog_ended_event.AddListener(Open_coin_decision_screen);
                break;
        }
    }

    private void Update()
    {
        Update_UI();
    }

    #region Core functions

    //Level 2 >>>

    private void Open_coin_decision_screen()
    {
        if(Game_manager_main.instance.Player_talked_to_president)
        {
            //Open screen
            PDecision.SetActive(true);
        }
    }

    public void Give_coin_to_president()
    {
        //Call event
        Events_main.instance.Player_gave_the_coin_to_president_event.Invoke();

        //Close screen
        PDecision.SetActive(false);
    }

    public IEnumerator Show_black_screen(float time, string msg)
    {
        //Open black screen
        PBlack_sreen.SetActive(true);

        //Set
        TBlack_screen_message.text = "";

        yield return new WaitForSeconds(time);

        //Set
        TBlack_screen_message.text = msg;

        yield return new WaitForSeconds(time);

        //Close black screen
        PBlack_sreen.SetActive(false);
    }

    #endregion

    #region Routine functions

    private void Update_UI()
    {
        //Set
        TObjective.text = Game_manager_main.instance.Objective_desc;
    }

    #endregion
}
