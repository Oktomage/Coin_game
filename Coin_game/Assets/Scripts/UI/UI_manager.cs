using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{
    [Header("Components")]
    public TextMeshProUGUI TObjective;

    private void Update()
    {
        Update_UI();
    }

    private void Update_UI()
    {
        TObjective.text = Game_manager_main.instance.Objective_desc;
    }
}
