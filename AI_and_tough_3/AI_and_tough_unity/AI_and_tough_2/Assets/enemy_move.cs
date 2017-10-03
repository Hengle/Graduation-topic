using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_move : MonoBehaviour
{
    public enum move_static {none,walk,run }

    [Header("移動腳本")]

    [Header("移動腳本狀態")]
    public move_static enemy_move_static = move_static.none;

    [Header("物體的NavMeshAgent組件")]
    public NavMeshAgent enemy_navmeshagent;

    [Header("目標點")]
    public Vector3 target;

    [Header("物體")]
    public GameObject enemy_game;

    [Header("從走變成跑距離")]
    public float walk_change_run_distance;

    [Header("從走變成跑距離，最小")]
    public float walk_change_run_distance_min;

    [Header("從走變成跑距離，最大")]
    public float walk_change_run_distance_max;

    [Header("從走變成跑時間")]
    public float walk_wait_time;

    [Header("從走變成跑時間，最小")]
    public float walk_wait_time_min;

    [Header("從走變成跑時間，最大")]
    public float walk_wait_time_max;

    [Header("跑步速度")]
    public float run_speed;

    [Header("走路速度")]
    public float walk_speed;

    public Vector3 enemy_last_vec3;

    public float enemy_stuck_time = 2f;

    private void Awake()
    {
        enemy_navmeshagent = AI_gameobject_all_manger.instance.enemy_nav;
        enemy_game = AI_gameobject_all_manger.instance.enemy;
    }

    // Use this for initialization
    void Start()
    {
        walk_wait_time = Random.Range(walk_wait_time_min, walk_wait_time_max);
        walk_change_run_distance = Random.Range(walk_change_run_distance_min, walk_change_run_distance_max);
    }

    private void Update()
    {
        if (enemy_move_static != move_static.none)
        {
            walk_wait_time -= Time.deltaTime;
        }
    }

    public void move_go_if()
    {
        if (enemy_move_static == move_static.none)
        {
            target = nav_map_manger.instance.map_point();
            walk_wait_time = Random.Range(walk_wait_time_min, walk_wait_time_max);
            walk_change_run_distance = Random.Range(walk_change_run_distance_min, walk_change_run_distance_max);
            judgment();
        }
        else if (enemy_move_static != move_static.none)
        {
            judgment();

            if (enemy_move_static == move_static.walk)
            {
                move_walk();
            }
            else if (enemy_move_static == move_static.run)
            {
                move_run();
            }
        }
     
    }

    void judgment()
    {
        if ((Vector3.Distance(enemy_game.transform.position, target) > walk_change_run_distance) && (walk_wait_time <= 0))
        {
            enemy_navmeshagent.speed = run_speed;
            enemy_move_static = move_static.run;
        }
        else if ((Vector3.Distance(enemy_game.transform.position, target) > walk_change_run_distance) && (walk_wait_time >= 0))
        {
            enemy_navmeshagent.speed = walk_speed;
            enemy_move_static = move_static.walk;
        }
       else if (Vector3.Distance(enemy_game.transform.position, target) < walk_change_run_distance)
        {
            enemy_navmeshagent.speed = walk_speed;
            enemy_move_static = move_static.walk;
        }
    }

    void move_walk()
    {
        enemy_navmeshagent.SetDestination(target);

        AI_tree_change.instance.change_animator_name("walk", true);
        AI_tree_change.instance.change_animator_name("run", false);
    }

    void move_run()
    {
        enemy_navmeshagent.SetDestination(target);

        AI_tree_change.instance.change_animator_name("walk", false);
        AI_tree_change.instance.change_animator_name("run", true);
    }

    public void move_tree_is_stuck()
    {


        //if (enemy_last_vec3 != enemy_game.transform.position)
        //{
        //    enemy_last_vec3 = enemy_game.transform.position;
        //}
        //else if ((enemy_last_vec3 == enemy_game.transform.position) && (ai_animator.GetBool("wait") == false))
        //{
        //    enemy_stuck_time -= 1f;
        //}

        //if (enemy_stuck_time <= 0)
        //{
        //    ai_animator.SetBool("wait", true);
        //    enemy_stuck_time = 2f;
        //}

    }

}
