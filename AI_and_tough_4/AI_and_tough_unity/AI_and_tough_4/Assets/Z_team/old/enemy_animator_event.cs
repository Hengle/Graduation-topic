using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_animator_event : MonoBehaviour
{

    public AI_gameobject_all _AI_gameobject_all;

    public AI_tree_change_manger _AI_tree_change_manger;

    public NavMeshAgent enemy_nav;

    public Animator enemy_animator;

    public bool jump;

    //public float work_speed;

    //public float run_speed;

    // Use this for initialization
    void Awake()
    {
        _AI_gameobject_all = this.GetComponent<AI_gameobject_all>();
        _AI_tree_change_manger = this.GetComponent<AI_tree_change_manger>();
        enemy_animator = _AI_gameobject_all.enemy_animator;
        enemy_nav = _AI_gameobject_all.enemy_nav;
        //work_speed = 3.5f;
        //run_speed = 7;
    }

    // Update is called once per frame
    void Update()
    {
        //print(enemy_nav.velocity.magnitude);
        move_animator();
    }

    void move_animator()
    {
        enemy_animator.SetFloat("speed", enemy_nav.velocity.magnitude);

        if (_AI_tree_change_manger.move_tree_name == "walk")
        {
            enemy_animator.SetBool("move", true);
        }

        if (_AI_tree_change_manger.move_tree_name == "jump")
        {
            enemy_animator.SetBool("jump", true);
        }

        if (_AI_tree_change_manger.move_tree_name != "jump")
        {
            enemy_animator.SetBool("jump", false);
        }

        if ((_AI_tree_change_manger.move_tree_name == "exit") || (_AI_tree_change_manger.move_tree_name == "wait"))
        {
            enemy_animator.SetBool("move", false);
        }

    }

}
