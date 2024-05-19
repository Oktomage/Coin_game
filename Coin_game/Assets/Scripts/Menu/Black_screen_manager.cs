using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Black_screen_manager : MonoBehaviour
{
    public static Black_screen_manager instance;

    [Header("Components")]
    public GameObject PBlack_screen;

    private void Awake()
    {
        instance = this;
    }

    #region Core functions

    public void Show_black_screen()
    {
        //Show black screen
        PBlack_screen.SetActive(true);

        //Fade in
        StartCoroutine("Fade_in");
    }

    IEnumerator Fade_in()
    {
        //Get
        Image black_screen_image = PBlack_screen.GetComponent<Image>();
        Color color = black_screen_image.color;

        //Set
        color.a = 0;

        //Fade in effect
        while(color.a < 1)
        {
            yield return new WaitForSeconds(0.1f);

            //Set
            color.a += 0.1f;

            black_screen_image.color = color;
        }    
    }

    #endregion
}
