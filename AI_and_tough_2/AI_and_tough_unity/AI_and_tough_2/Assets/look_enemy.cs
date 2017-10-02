using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class look_enemy : MonoBehaviour
{

    public AI_gameobject_all _AI_gameobject_all;

    public event_name _event_name;

    public static string ID = "look_enemy";

    public NavMeshAgent enemy_nav;

    //public bool is_on;

    private void Awake()
    {
        _AI_gameobject_all = this.GetComponent<AI_gameobject_all>();
        enemy_nav = _AI_gameobject_all.enemy_nav;
        _event_name = this.GetComponent<event_name>();
    }

    //public void look_enemy_on()
    //{
    //    if(_event_name._AI_look_event_manger_event_name != ID)
    //    {
    //        return;
    //    }
    //    _AI_gameobject_all.enemy_animator.SetBool("look_enemy", true);
    //    enemy_nav.isStopped = true;
    //    if(flag == true)
    //    {
    //        enemy_nav.isStopped = false;
    //        flag = false;
    //        _AI_gameobject_all.enemy_animator.SetBool("look_enemy", false);
    //        _event_name.events_close();
    //        return;
    //    }
    //    flag = true;
    //}

    public void look_enemy_on()
    {
        //if (((_event_name._AI_look_event_manger_event_name != ID) && (is_on == true)) == true)
        if (_event_name._AI_look_event_manger_event_name != ID)
        {
            return;
        }
        _AI_gameobject_all.enemy_animator.SetBool("look_enemy", true);
        enemy_nav.isStopped = true;
        //is_on = true;


    }

    public void look_enemy_off()
    {
      

        //is_on = false;
        enemy_nav.isStopped = false;
        _AI_gameobject_all.enemy_animator.SetBool("look_enemy", false);
        _event_name.events_close();

    }

}
