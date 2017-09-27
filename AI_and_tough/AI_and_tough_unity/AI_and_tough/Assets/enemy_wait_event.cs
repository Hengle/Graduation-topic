﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_wait_event : MonoBehaviour {

    public AI_tree_change_manger _AI_tree_change_manger;

    public float time;

    public float time_max;

    public float time_min;

    public bool check;

    private void Awake()
    {
        _AI_tree_change_manger = this.GetComponent<AI_tree_change_manger>();
    }

    // Use this for initialization
    void Start () {
        time = Random.Range(time_min, time_max);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void wait()
    {
        if ((check == false) && (time > 0)) 
        {
            check = true;
        }

        if (check == true)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                _AI_tree_change_manger.change_animator_name("move", true);
                check = false;
            }
        }
    }

    public void wait_off()
    {
        check = false;
        time = Random.Range(time_min, time_max);
    }

}
