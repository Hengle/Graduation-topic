using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class event_all : MonoBehaviour {

    public enemy_ai_manger _enemy_ai_manger;

    public enemy_ai_wait _enemy_ai_wait;

    public enemy_ai_move _enemy_ai_move;

    public NavMeshAgent enemy_nav;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void event_ID(string id,GameObject id_gameObject)
    {
        switch(id)
        {
            case "music_boob":
                music_boob(id_gameObject);
                break;
            default:
                print("Error : Event none"+ "   " + id);
                break;
        }
    }

    void music_boob(GameObject id_gameObject)
    {
        //print("music_boob" + id_gameObject.name);

        //_enemy_ai_manger.enemy_static_now = enemy_ai_manger.enemy_static.exit;
        //enemy_nav.SetDestination(id_gameObject.transform.position);

        _enemy_ai_move.target = id_gameObject.transform.position;

    }

}
