using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event_name : MonoBehaviour
{

    public AI_look_event_manger _AI_look_event_manger;

    public Animator _AI_look_event_manger_animator;

    public string _AI_look_event_manger_event_name;

    // Update is called once per frame
    void Update()
    {
        _AI_look_event_manger_event_name = _AI_look_event_manger.look_tree_name;
        _AI_look_event_manger_animator = _AI_look_event_manger._look_tree_animator;
    }

    public void events_close()
    {
        //_AI_look_event_manger.is_on = false;
        _AI_look_event_manger_animator.SetBool("event", true);
    }


}
