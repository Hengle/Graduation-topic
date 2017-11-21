using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class enemy_ai_manger : MonoBehaviour
{
    public enum enemy_static {wait,move,exit}

    public enemy_static enemy_static_now;

    public UnityEvent wait;

    public UnityEvent move;

    public UnityEvent exit;

    public NavMeshAgent enemy_nav;

   


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //move.Invoke();

        switch(enemy_static_now)
        {
            case enemy_static.wait:
                wait.Invoke();
                break;
            case enemy_static.move:
                move.Invoke();
                break;
            case enemy_static.exit:
                exit.Invoke();
                break;
            default:
                break;
        }
    }

    public void Exit()
    {
        enemy_static_now = enemy_static.wait;
        enemy_nav.enabled = true;
        enemy_nav.isStopped = false;
    }



}
