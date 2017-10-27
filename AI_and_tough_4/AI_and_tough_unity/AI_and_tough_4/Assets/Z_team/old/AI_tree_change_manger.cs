using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AI_tree_change_manger : MonoBehaviour
{

    //public Animator _ai_tree_animator;

    //public string move_tree_name;

    //public enemy_move_event _enemy_move_script;

    //public enemy_jump_event _enemy_jump_event;

    //public enemy_wait_event _enemy_wait_event;

    //public UnityEvent exit;


    //void Awake()
    //{
    //    _enemy_move_script = this.GetComponent<enemy_move_event>();
    //    _ai_tree_animator = this.GetComponent<Animator>();
    //    _enemy_jump_event = this.GetComponent<enemy_jump_event>();
    //    _enemy_wait_event = this.GetComponent<enemy_wait_event>();
    //}


    //// Use this for initialization
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    move_tree_if();
    //}

    //public void null_function()
    //{

    //}

    //public void change_animator_name(string name, bool status_bool)
    //{
    //    _ai_tree_animator.SetBool(name, status_bool);
    //}

    //public bool get_animator_name(string name)
    //{
    //    return _ai_tree_animator.GetBool(name);
    //}

    //public void animator_name(string name)
    //{
    //    move_tree_name = name;
    //}

    //void move_tree_if()
    //{
    //    switch (move_tree_name)
    //    {
    //        case "wait":
    //            _enemy_wait_event.wait();
    //            break;
    //        case "move":
    //            _ai_tree_animator.SetBool("walk", true);
    //            break;
    //        case "walk":
    //            _enemy_move_script.move_go_if();
    //            break;
    //        case "run":
    //            _enemy_move_script.move_go_if();
    //            break;
    //        case "jump":
    //            _enemy_jump_event.check_gameobject();
    //            break;
    //        case "exit":
    //            exit.Invoke();
    //            break;
    //        default:
    //            break;
    //    }
    //}

    //public void ai_change_off()
    //{
    //    _ai_tree_animator.SetBool("move",false);
    //    _ai_tree_animator.SetBool("walk", false);
    //    _ai_tree_animator.SetBool("run", false);
    //    _ai_tree_animator.SetBool("exit", false);
    //    _ai_tree_animator.SetBool("jump", false);
    //}

    public Animator _ai_tree_animator;

    public string move_tree_name;

    public enemy_move_event _enemy_move_script;

    public enemy_jump_event _enemy_jump_event;

    public enemy_wait_event _enemy_wait_event;

    public UnityEvent wait;

    public UnityEvent walk_run;

    public UnityEvent jump;

    public UnityEvent exit;

    public UnityEvent ai_rester;


    void Awake()
    {
        _enemy_move_script = this.GetComponent<enemy_move_event>();
        _ai_tree_animator = this.GetComponent<Animator>();
        _enemy_jump_event = this.GetComponent<enemy_jump_event>();
        _enemy_wait_event = this.GetComponent<enemy_wait_event>();
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move_tree_if();
    }

    public void null_function()
    {

    }

    public void change_animator_name(string name, bool status_bool)
    {
        _ai_tree_animator.SetBool(name, status_bool);
    }

    public bool get_animator_name(string name)
    {
        return _ai_tree_animator.GetBool(name);
    }

    public void animator_name(string name)
    {
        move_tree_name = name;
    }

    public void change_animator_name_false(string name)
    {
        _ai_tree_animator.SetBool(name, false);
    }

    void move_tree_if()
    {
        switch (move_tree_name)
        {
            case "wait":
                //_enemy_wait_event.wait();
                wait.Invoke();
                break;
            case "walk":
                //_enemy_move_script.move_go_if();
                walk_run.Invoke();
                break;
            case "run":
                //_enemy_move_script.move_go_if();
                walk_run.Invoke();
                break;
            case "jump":
                //_enemy_jump_event.check_gameobject();
                jump.Invoke();
                break;
            case "exit":
                exit.Invoke();
                ai_rester.Invoke();
                break;
            default:
                break;
        }
    }

    //public void ai_change_off()
    //{
    //    _ai_tree_animator.SetBool("move", false);
    //    _ai_tree_animator.SetBool("walk", false);
    //    _ai_tree_animator.SetBool("run", false);
    //    _ai_tree_animator.SetBool("exit", false);
    //    _ai_tree_animator.SetBool("jump", false);
    //}


}
