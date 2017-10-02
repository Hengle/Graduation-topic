using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AI_look_event_manger : MonoBehaviour {

    public Animator _look_tree_animator;

    public string look_tree_name = "null";

    public bool is_on = false;

    public UnityEvent events;

    public UnityEvent ai_rester;

    void Awake()
    {
        _look_tree_animator = this.GetComponent<Animator>();
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (look_tree_name == "exit")
        {
            ai_rester.Invoke();
        }
        else if ((look_tree_name != "null") && (is_on == false)) 
        {
            is_on = true;
            events.Invoke();
        }
    }

    public void null_function()
    {

    }

    public void change_animator_name(string name, bool status_bool)
    {
        _look_tree_animator.SetBool(name, status_bool);
    }

    public bool get_animator_name(string name)
    {
        return _look_tree_animator.GetBool(name);
    }

    public void animator_name(string name)
    {
        look_tree_name = name;
    }

    public void change_animator_name_false(string name)
    {
        _look_tree_animator.SetBool(name, false);
    }


}
