using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class event_all : MonoBehaviour {

    public enemy_ai_manger _enemy_ai_manger;

    public enemy_ai_wait _enemy_ai_wait;

    public enemy_ai_move _enemy_ai_move;

    public NavMeshAgent enemy_nav;

    public GameObject eye;

    [Header("陷阱-----------------------------------")]
    [Header("陷阱時間")]
    public float trap_time;

    public bool trap_on;

    [Header("閃光彈---------------------------------")]
    [Header("延遲時間")]
    public float flashlight_time_last;

    public float flashlight_time;

    public bool flashlight_on;

    // Use this for initialization
    void Start()
    {
        flashlight_time = flashlight_time_last;
    }

    // Update is called once per frame
    void Update()
    {
        if(flashlight_on ==true)
        {
            flashlight();
        }

        if (trap_on == true)
        {
            trap();
        }

    }

    public void event_ID(string id, GameObject id_gameObject)
    {
        switch (id)
        {
            case "music_boob":
                music_boob(id_gameObject);
                break;
            case "Invasion":
                print("Invasion");
                break;
            case "trap":
                //print("Invasion");
                //trap();
                trap_on = true;
                break;
            case "Flashlight":
                flashlight_on = true;
                break;
            case "music":
                music_boob(id_gameObject);
                break;
            case "look_prop":
                print("look_prop");
                break;
            default:
                print("Error : Event none" + "   " + id);
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

    void trap()
    {
        _enemy_ai_wait.time = trap_time;
    }

    void flashlight()
    {
        if(flashlight_time > 0)
        {
            eye.transform.localScale = new Vector3(0.3f, 0.3f, 1);
            flashlight_time -= Time.deltaTime;
        }
        else
        {
            eye.transform.localScale = Vector3.one;
            flashlight_time = flashlight_time_last;
            flashlight_on = false;
        }
    }

}
