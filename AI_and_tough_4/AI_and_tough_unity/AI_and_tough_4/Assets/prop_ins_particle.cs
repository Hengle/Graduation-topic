using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prop_ins_particle : MonoBehaviour
{

    public GameObject particle;

    public float des_time;

    public float time;

    // Use this for initialization
    void Start()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            GameObject des_game = GameObject.Instantiate(particle, this.gameObject.transform.position, Quaternion.identity);
            Destroy(des_game, des_time);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            GameObject des_game = GameObject.Instantiate(particle, this.gameObject.transform.position, Quaternion.identity);
            Destroy(des_game, des_time);
            Destroy(this);
        }
    }
}
