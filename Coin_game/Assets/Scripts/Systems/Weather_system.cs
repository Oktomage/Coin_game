using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather_system : MonoBehaviour
{
    [Header("Configs")]
    public bool Active;

    [Space(10)]
    [Range(0f, 0.1f)]
    public float Drop_interval;

    private void Start()
    {
        if(Active)
        {
            StartCoroutine("Raining");
        }
    }

    IEnumerator Raining()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        while(Active)
        {
            yield return new WaitForSeconds(Drop_interval);

            //Get pos
            Vector2 pos = new Vector2(Player.transform.position.x + Random.Range(-20f, 20f), Player.transform.position.y + Random.Range(10f, 20f));

            //Create it
            float speed = Random.Range(5f, 10f);

            Create_drop_entity(pos, speed);
        }
    }

    private void Create_drop_entity(Vector2 pos, float spd)
    {
        GameObject drop_entity = Instantiate(Resources.Load("Prefabs/Entitys/Drop_entity"), pos, Quaternion.identity) as GameObject;

        //Configure
        drop_entity.GetComponent<Drop_entity>().Configure(spd);
    }
}
