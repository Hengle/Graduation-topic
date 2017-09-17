using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_tree_change : MonoBehaviour {

    public Animator ai_tree_animator;

    public string move_tree_name;

	// Use this for initialization
	void Start () {
		
	}

    public ray test;
	
	// Update is called once per frame
	void Update () {
        AI_gameobject_all_manger.instance.enemy_nav.SetDestination(test.target);
	}

    public void null_function()
    {

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

                break;
            case "run":

                break;
            case "jump":

                break;
            default:
                break;
        }
    }

}
