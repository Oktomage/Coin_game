using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog_system : MonoBehaviour
{
    public static Dialog_system instance;

    [Header("Configs")]
    [Range(0, 0.2f)]
    public float Char_speed;
    [Range(0, 6f)]
    public float Delay_between_strings;

    [Header("List")]
    public List<string> Txt_list = new List<string>();

    [Header("Components")]
    public GameObject PDialog_hud;
    public TextMeshProUGUI TDialog;

    //Internal vars
    internal bool Texting;

    private void Awake()
    {
        instance = this;
    }

    #region Core functions

    public void Request_text(string txt)
    {
        Txt_list.Add(txt);

        //Start
        StartCoroutine("Text_machine");
    }

    public void Request_text(List<string> txts)
    {
        foreach (string txt in txts)
        {
            Txt_list.Add(txt);
        }

        //Start
        StartCoroutine("Text_machine");
    }

    IEnumerator Text_machine()
    {
        GameObject plr_obj = GameObject.FindGameObjectWithTag("Player");

        //Freeze player
        plr_obj.GetComponent<Humanoid_body>().Can_move = false;

        //Open dialog hud
        PDialog_hud.SetActive(true);

        //Write text
        string text_generated;

        while(Txt_list.Count > 0)
        {
            //Reset string var
            text_generated = "";

            foreach (char c in Txt_list[0])
            {
                //Get
                text_generated += c;

                //Set
                TDialog.text = text_generated;

                yield return new WaitForSeconds(Char_speed);
            }

            //Remove index 0 from txt list
            Txt_list.RemoveAt(0);

            //Delay
            yield return new WaitForSeconds(Delay_between_strings);
        }

        //Unfreeze player
        plr_obj.GetComponent<Humanoid_body>().Can_move = true;

        //Close dialog hud
        PDialog_hud.SetActive(false);

        //Call event
        Events_main.instance.Dialog_ended_event.Invoke();
    }

    #endregion
}
