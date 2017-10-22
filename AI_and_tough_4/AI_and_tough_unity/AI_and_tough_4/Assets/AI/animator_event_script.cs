using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class animator_event_script : MonoBehaviour {

    public Animator ai_animator;

    public Animator player_animator;

    public NavMeshAgent player_agent;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void look_enemy_end()
    {
        player_agent.enabled = true;
        ai_animator.SetBool("look_enemy", false);
        player_animator.SetBool("hurt", false);
        player_agent.isStopped = false;
    }

}
