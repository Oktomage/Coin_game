using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_system : MonoBehaviour
{
    public static Particle_system instance;

    private void Awake()
    {
        instance = this;
    }

    #region Core functions

    public void Create_particle(string particleName, Vector2 pos)
    {
        GameObject particle = Instantiate(Resources.Load("Prefabs/Particles/" + particleName), pos, Quaternion.identity) as GameObject;

        particle.transform.position = pos;
    }

    #endregion
}
