using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_move_event : MonoBehaviour
{

    public AI_gameobject_all _AI_gameobject_all;

    public AI_tree_change_manger _AI_tree_change_manger;

    public enemy_jump_event _enemy_jump_event;

    public enum move_static { none, walk, run }

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

    
    [Header("走路速度")]
    public float walk_speed;

    [Header("跑步速度")]
    public float run_speed;

    [Header("上一個位置")]
    public Vector3 enemy_last_vec3;

    [Header("卡住倒數")]
    public float enemy_stuck_time;

    [Header("卡住倒數(原本)")]
    public float enemy_stuck_time_last;

    public bool is_jump = false;

    private void Awake()
    {
        _AI_gameobject_all = this.GetComponent<AI_gameobject_all>();
        _AI_tree_change_manger = this.GetComponent<AI_tree_change_manger>();
        _enemy_jump_event = this.GetComponent<enemy_jump_event>();
        enemy_navmeshagent = _AI_gameobject_all.enemy_nav;
        enemy_game = _AI_gameobject_all.enemy;
        enemy_stuck_time = enemy_stuck_time_last;
    }

    // Use this for initialization
    void Start()
    {
        walk_wait_time = Random.Range(walk_wait_time_min, walk_wait_time_max);
        walk_change_run_distance = Random.Range(walk_change_run_distance_min, walk_change_run_distance_max);
    }

    // Update is called once per frame
    void Update()
    {
        //if (enemy_move_static != move_static.none)
        //{
        //    walk_wait_time -= Time.deltaTime;
        //}
        //print(_AI_gameobject_all.enemy_nav.isStopped);
    }

    public void move_go_if()
    {
        if (is_jump == true)
        {
            return;
        }

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
            jump_if();
            walk_wait_time -= Time.deltaTime;

            if (enemy_move_static == move_static.walk)
            {
                move_walk();
            }
            else if (enemy_move_static == move_static.run)
            {
                move_run();
            }

            move_tree_is_stuck();

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

        //AI_tree_change.instance.change_animator_name("walk", true);
        //AI_tree_change.instance.change_animator_name("run", false);
        _AI_tree_change_manger.change_animator_name("walk", true);
        _AI_tree_change_manger.change_animator_name("run", false);
    }

    void move_run()
    {
        enemy_navmeshagent.SetDestination(target);

        _AI_tree_change_manger.change_animator_name("walk", false);
        _AI_tree_change_manger.change_animator_name("run", true);
    }

    public void move_tree_is_stuck()
    {


        if (enemy_last_vec3 != enemy_game.transform.position)
        {
            enemy_last_vec3 = enemy_game.transform.position;
        }
        else if ((enemy_last_vec3 == enemy_game.transform.position) && (_AI_tree_change_manger.get_animator_name("exit") == false))
        {
            enemy_stuck_time -= Time.deltaTime;
        }

        if (enemy_stuck_time <= 0)
        {
            //enemy_move_static = move_static.none;
            _AI_tree_change_manger.change_animator_name("exit", true);
            enemy_stuck_time = enemy_stuck_time_last;
        }

    }

    void jump_if()
    {
        if (enemy_navmeshagent.isOnOffMeshLink == true)
        {
            //jump_star = player_agent.currentOffMeshLinkData.startPos;
            //jump_end = player_agent.currentOffMeshLinkData.endPos;
            //player_animator.SetBool("jump bool", true);
            //player_agent.enabled = false;
            _enemy_jump_event.start_pos = enemy_navmeshagent.currentOffMeshLinkData.startPos;
            _enemy_jump_event.end_pos = enemy_navmeshagent.currentOffMeshLinkData.endPos;
            enemy_navmeshagent.enabled = false;
            is_jump = true;
            _AI_tree_change_manger.change_animator_name("jump", true);
            _AI_tree_change_manger.change_animator_name("walk", false);
            _AI_tree_change_manger.change_animator_name("run", false);
            //print(enemy_navmeshagent.currentOffMeshLinkData.startPos +" " + enemy_navmeshagent.currentOffMeshLinkData.endPos);
        }
        //else if (enemy_navmeshagent.isOnOffMeshLink == false)
        //{
        //    _AI_tree_change_manger.change_animator_name("jump", false);
        //    enemy_navmeshagent.enabled = true;
        //}
    }

    public void move_exit()
    {
        enemy_move_static = move_static.none;

        enemy_navmeshagent.enabled = true;

        enemy_navmeshagent.speed = walk_speed;

        target = Vector3.zero;

        walk_change_run_distance = 0;

        walk_wait_time = 0;

        enemy_last_vec3 = Vector3.zero;

        is_jump = false;
    }


}
