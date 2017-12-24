using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class animator_event : MonoBehaviour {

    public Animator _enemy_animator;

    public NavMeshAgent enemy_nav;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Exit()
    {
        //enemy_nav.enabled = true;
        _enemy_animator.SetBool("idel", true);
        _enemy_animator.SetBool("walk", false);
        _enemy_animator.SetBool("run", false);
        _enemy_animator.SetBool("event", false);
        _enemy_animator.SetBool("blindess", false);
        _enemy_animator.SetBool("demonstration", false);
        _enemy_animator.SetBool("heart_sound", false);
        _enemy_animator.SetBool("gosh", false);
        _enemy_animator.SetBool("can_t_heart", false);
    }

}
