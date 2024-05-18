using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_system : MonoBehaviour
{
    public static Sound_system instance;

    private void Awake()
    {
        instance = this;
    }

    #region Core functions

    public void Create_sound(string sound_name, float sound_volume)
    {
        GameObject new_sound = new GameObject(sound_name);

        //Add components
        new_sound.AddComponent<AudioSource>();

        //Set
        new_sound.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/" + sound_name);
        new_sound.GetComponent<AudioSource>().volume = sound_volume;

        //Play
        new_sound.GetComponent<AudioSource>().Play();
    }

    #endregion
}
