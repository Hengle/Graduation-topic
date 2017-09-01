using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_move_tree : MonoBehaviour
{

    public NavMeshAgent player_agent;
    public Vector3 target;
    public Animator player_animator;
    public Animator ai_animator;
    public GameObject player;

    public float max_distance = 15;

    public float walk_wait_time;

    public float run_speed = 7;

    public float walk_speed = 3.5f;

    public float wait_time;

    public float wait_time_min;

    public float wait_time_max;

    public Vector3 jump_star;

    public Vector3 jump_end;

    private void Awake()
    {
        player_agent = player.GetComponent<NavMeshAgent>();
        player_animator = player.GetComponent<Animator>();
        ai_animator = this.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {
        wait_time = Random.Range(wait_time_min, wait_time_max);
    }

    // Update is called once per frame
    void Update()
    {
        player_animator.SetFloat("speed", player_agent.velocity.sqrMagnitude);
    }

    public void null_function()
    {

    }

    public ray ray;

    public void move_tree_move()
    {
        //target = nav_map_manger.instance.map_point();

        target = ray.target;//test

        walk_wait_time = Random.Range(1f, 5f);

        player_agent.SetDestination(target);
        ai_animator.SetBool("walk", true);
        ai_animator.SetBool("move", false);
    }

    public void move_tree_walk()
    {
        walk_wait_time -= 1f;

        if ((Vector3.Distance(player.transform.position, target) > max_distance) && (walk_wait_time <= 0)) 
        {
            player_agent.speed = run_speed;

            ai_animator.SetBool("walk", false);
            ai_animator.SetBool("run", true);
        }

        if(Vector3.Distance(player.transform.position, target) < 1f)
        {
            ai_animator.SetBool("wait", true);
        }
    }

    public void move_tree_run()
    {
        if (Vector3.Distance(player.transform.position, target) < max_distance)
        {
            player_agent.speed = walk_speed;

            ai_animator.SetBool("walk", true);
            ai_animator.SetBool("run", false);
        }
    }

    public void move_tree_exit()
    {
        target =new  Vector3(0, 0, 0);

        walk_wait_time = 0;

        wait_time = Random.Range(wait_time_min, wait_time_max);

        player_agent.speed = walk_speed;

        ai_animator.SetBool("walk", false);
        ai_animator.SetBool("run", false);
        ai_animator.SetBool("move", false);
        ai_animator.SetBool("wait", false);
    }

    public void  move_tree_wait()
    {
        wait_time -= 1f;

        if(wait_time <= 0)
        {
            ai_animator.SetBool("move", true);
        }
    }

    public void move_tree_is_jump()
    {
        //if(player_agent.isOnOffMeshLink == true)
        //{
        //    player_agent.enabled = false;

        //    jump_star = player_agent.currentOffMeshLinkData.startPos;
        //    jump_end = player_agent.currentOffMeshLinkData.endPos;
        //}
    }

}
