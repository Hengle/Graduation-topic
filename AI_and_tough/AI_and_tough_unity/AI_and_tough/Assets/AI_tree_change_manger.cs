using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_tree_change_manger : MonoBehaviour
{

    public Animator ai_tree_animator;

    public string move_tree_name;

    public enemy_move_event enemy_move_script;

    void Awake()
    {
        enemy_move_script = this.GetComponent<enemy_move_event>();
        ai_tree_animator = this.GetComponent<Animator>();
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
        ai_tree_animator.SetBool(name, status_bool);
    }

    public bool get_animator_name(string name)
    {
        return ai_tree_animator.GetBool(name);
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
                enemy_move_script.move_go_if();
                break;
            case "run":
                enemy_move_script.move_go_if();
                break;
            case "jump":

                break;
            default:
                break;
        }
    }

}
