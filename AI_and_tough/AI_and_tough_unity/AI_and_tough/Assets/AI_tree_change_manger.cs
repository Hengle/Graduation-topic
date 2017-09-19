using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_tree_change_manger : MonoBehaviour {

    public Animator ai_tree_animator;

    public string move_tree_name;

    public enemy_move enemy_move_script;

    void Awake()
    {
        enemy_move_script = this.GetComponent<enemy_move>();
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void null_function()
    {

    }

    public void change_animator_name(string name, bool status_bool)
    {
        ai_tree_animator.SetBool(name, status_bool);
    }

    public void animator_name(string name)
    {
        move_tree_name = name;
    }


}
