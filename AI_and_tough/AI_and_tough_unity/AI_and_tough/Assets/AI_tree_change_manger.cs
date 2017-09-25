using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_tree_change_manger : MonoBehaviour
{

    public Animator _ai_tree_animator;

    public string move_tree_name;

    public enemy_move_event _enemy_move_script;

    public enemy_jump_event _enemy_jump_event;

    void Awake()
    {
        _enemy_move_script = this.GetComponent<enemy_move_event>();
        _ai_tree_animator = this.GetComponent<Animator>();
        _enemy_jump_event = this.GetComponent<enemy_jump_event>();
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

    void move_tree_if()
    {
        switch (move_tree_name)
        {
            case "wait":

                break;
            case "move":

                break;
            case "walk":
                _enemy_move_script.move_go_if();
                break;
            case "run":
                _enemy_move_script.move_go_if();
                break;
            case "jump":
                _enemy_jump_event.check_gameobject();
                break;
            default:
                break;
        }
    }

}
