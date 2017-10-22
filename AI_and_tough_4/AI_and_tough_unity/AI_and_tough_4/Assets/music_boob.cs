using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_boob : MonoBehaviour
{

    public LayerMask layer;

    public float range;

    public GameObject boob;

    public bool boob_bool;

    public float time;

    public Collider[] enemy;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        testdraw();
        if (time > 0)
        {
            if(boob_bool == false)
            {
                GameObject.Instantiate(boob, this.transform.position, Quaternion.identity);
                boob_bool = true;
            }
            music_boob_on();
            time -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    void music_boob_on()
    {
        enemy = Physics.OverlapSphere(this.transform.position, range, layer);
        if(enemy == null)
        {
            return;
        }
        foreach (Collider serch_colloder in enemy)
        {
            serch_colloder.transform.GetComponentInChildren<enemy_wait_event>().time = 0;
            serch_colloder.transform.GetComponentInChildren<enemy_move_event>().target = this.transform.position;
        }
    }

    void testdraw()
    {
        Debug.DrawRay(this.transform.position,Vector3.back * range, Color.black);
        Debug.DrawRay(this.transform.position, Vector3.down * range, Color.black);
        Debug.DrawRay(this.transform.position, Vector3.forward * range, Color.black);
        Debug.DrawRay(this.transform.position, Vector3.left * range, Color.black);
        Debug.DrawRay(this.transform.position, Vector3.right * range, Color.black);
        Debug.DrawRay(this.transform.position, Vector3.up * range, Color.black);
    }

}
