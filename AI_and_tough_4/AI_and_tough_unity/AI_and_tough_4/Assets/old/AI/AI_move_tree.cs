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

    //public Vector3 jump_star;

    public Vector3 jump_end;

    public bool jumping_bool = false;

    public Vector3 player_last_vec3;

    public float player_stuck_time = 2f;

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
        player_animator.SetFloat("jump", Mathf.Abs(player_agent.velocity.y));
        //print(player_agent.velocity + " " + player_agent.velocity.sqrMagnitude + " " + player.GetComponent<Rigidbody>().velocity);
        //player_animator.SetFloat("speed", player.GetComponent<Rigidbody>().velocity.sqrMagnitude);
        //print(player.GetComponent<Rigidbody>().velocity.sqrMagnitude);

        //if (jumping_bool == true)
        //{

        //    jumping();
        //}

        //print(player_agent.pathStatus);

    }

    public void null_function()
    {

    }

    //public ray ray;

    public void move_tree_move()
    {
        target = nav_map_manger.instance.map_point();

        //target = ray.target;//test

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

        if (Vector3.Distance(player.transform.position, target) < 1f)
        {
            ai_animator.SetBool("wait", true);
        }

    }

    public void move_tree_exit()
    {
        target = Vector3.zero;

        walk_wait_time = 0;

        wait_time = Random.Range(wait_time_min, wait_time_max);

        player_agent.speed = walk_speed;

        //jump_star = Vector3.zero;
        jump_end = Vector3.zero;

        ai_animator.SetBool("walk", false);
        ai_animator.SetBool("run", false);
        ai_animator.SetBool("move", false);
        ai_animator.SetBool("wait", false);
        ai_animator.SetBool("jump", false);
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
        if (player_agent.isOnOffMeshLink == true)
        {
            //jump_star = player_agent.currentOffMeshLinkData.startPos;
            jump_end = player_agent.currentOffMeshLinkData.endPos;
            //player_animator.SetBool("jump bool", true);
            //player_agent.enabled = false;
            ai_animator.SetBool("jump", true);
        }
    }

    public void move_tree_jumping()
    {
        //player.transform.position = Vector3.Lerp(jump_star, jump_end, 10f);
        //player.transform.position = Vector3.Lerp(player.transform.position, jump_end, 1f);
        //jumping_bool = true;
    }

    void jumping()
    {

        Vector3 next_pos;
        //player.transform.position = Vector3.Lerp(player.transform.position, jump_end, 1f * Time.deltaTime);
        next_pos = Vector3.Lerp(player.transform.position, jump_end, 1f * Time.deltaTime);
        player_animator.SetFloat("jump", Mathf.Abs(next_pos.y - player.transform.position.y));
        
        print(next_pos + " " + player.transform.position + " " + (next_pos - player.transform.position));
        player.transform.position = next_pos;
    }

    public void move_tree_is_stuck()
    {


        if (player_last_vec3 != player.transform.position)
        {
            player_last_vec3 = player.transform.position;
        }
        else if ((player_last_vec3 == player.transform.position) && (ai_animator.GetBool("wait") == false)) 
        {
            player_stuck_time -= 1f;
        }

        if(player_stuck_time <= 0)
        {
            ai_animator.SetBool("wait", true);
            player_stuck_time = 2f;
        }

    }

}
