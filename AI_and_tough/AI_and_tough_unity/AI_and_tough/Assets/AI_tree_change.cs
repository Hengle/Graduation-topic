using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_tree_change : MonoBehaviour {

    public Animator ai_tree_animator;

    public string move_tree_name;

    public enemy_move enemy_move_script;

    private static AI_tree_change _instance;

    public static AI_tree_change instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
        enemy_move_script = this.GetComponent<enemy_move>();
    }

    // Use this for initialization
    void Start () {
		
	}

    //public ray test;
	
	// Update is called once per frame
	void Update () {
        //AI_gameobject_all_manger.instance.enemy_nav.SetDestination(test.target);
        move_tree_if();
    }

    public void null_function()
    {

    }

    public void change_animator_name(string name,bool status_bool)
    {
        ai_tree_animator.SetBool(name, status_bool);
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
