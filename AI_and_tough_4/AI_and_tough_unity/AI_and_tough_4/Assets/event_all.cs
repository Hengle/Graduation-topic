using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class event_all : MonoBehaviour {

    [Header("飢餓值")]
    public float hunger_value;
    [Header("飢餓值(滿)")]
    public float hunger_value_last;
    [Header("心情值")]
    public float mood_value;
    [Header("心情值(滿)")]
    public float mood_value_last;
    //[Header("心情值扣冷卻時間")]
    //public float mood_value_remove_time;
    //[Header("心情值扣冷卻時間(滿)")]
    //public float mood_value_remove_time_last;
    [Header("入侵度")]
    public float Invasion_value;
    [Header("入侵度(滿)")]
    public float Invasion_value_last;
    [Header("飢餓值每秒減多少")]
    public float hunger_value_remove_sec;
    [Header("心情值一次減多少")]
    public float mood_value_remove;
    [Header("入侵度每秒加多少")]
    public float Invasion_value_add;


    public enemy_ai_manger _enemy_ai_manger;

    public enemy_ai_wait _enemy_ai_wait;

    public enemy_ai_move _enemy_ai_move;

    public NavMeshAgent enemy_nav;

    public GameObject eye;

    public ui_vanves_manger _ui_canves_manger;

    //[Header("入侵-----------------------------------")]
    //[Header("(1)入侵啟動")]
    //public bool invasion_bool;

    [Header("陷阱-----------------------------------")]
    [Header("(1)陷阱啟動")]
    public bool trap_on;
    [Header("(2)陷阱時間")]
    public float trap_time;
    [Header("(3)陷阱時間(原本)")]
    public float trap_time_last;
    //[Header("(3)陷阱啟動拒絕(以免一直卡住)")]
    //public bool trap_event_off;
    [Header("(4)陷阱冷卻時間")]
    public float trap_cool_time;
    [Header("(5)陷阱冷卻時間(原本)")]
    public float trap_cool_time_last;

    [Header("閃光彈---------------------------------")]
    [Header("(1)閃光彈時間(原本)")]
    public float flashlight_time_last;
    [Header("(2)閃光彈時間")]
    public float flashlight_time;
    [Header("(3)閃光彈啟動")]
    public bool flashlight_on;

    

    // Use this for initialization
    void Awake()
    {
        flashlight_time = flashlight_time_last;
        trap_time = trap_time_last;
        trap_cool_time = trap_cool_time_last + trap_time_last;
        mood_value = mood_value_last;
        hunger_value = hunger_value_last;
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

        //if (invasion_bool == true) 
        //{
        //    Invasion_on();
        //}

        hunger_value -= hunger_value_remove_sec * Time.deltaTime;
        
    }

    public void event_ID(string id, GameObject id_gameObject)
    {
        switch (id)
        {
            case "music_boob":
                music_boob(id_gameObject);
                break;
            case "Invasion":
                //print("Invasion");
                //invasion_bool = true;
                Invasion_on();
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
                //print("look_prop");
                look_prop(id_gameObject);
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
        //if (trap_on == true)
        //{
        //    _enemy_ai_wait.time = trap_time_event;
        //    //trap_event_off = true;
        //}



        //if ((trap_time > 0) && (trap_event_off == false))
        //{
        //    //_enemy_ai_manger.enemy_static_now = enemy_ai_manger.enemy_static.exit;

        //    enemy_nav.enabled = false;
        //    trap_time -= Time.deltaTime;

        //    //_enemy_ai_wait.time = trap_time_event;
        //    //trap_event_off = true;

        //}
        //else if ((trap_time > 0) && (trap_event_off == true))
        //{

        //}
        //else
        //{
        //    trap_time = trap_time_last;
        //    //trap_event_off = false;
        //    trap_on = false;
        //}

        //if (trap_time > 0)
        //{
            
        //    trap_time -= Time.deltaTime;
        //}
        //else
        //{
           
        //    trap_time = flashlight_time_last;
        //    trap_on = false;
        //}

        if(trap_cool_time > 0)
        {
            if(trap_time > 0)
            {
                enemy_nav.enabled = false;
                trap_time -= Time.deltaTime;
            }
            trap_cool_time -= Time.deltaTime;
        }
        else
        {
            trap_time = trap_time_last;
            trap_cool_time = trap_cool_time_last + trap_time_last;
            trap_on = false;
        }

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

    void Invasion_on()
    {
        Invasion_value += Invasion_value_add * Time.deltaTime;
        //print(Invasion_value + " " + Time.time);
        if(Invasion_value >= Invasion_value_last)
        {
            Invasion_value = 0;
            _ui_canves_manger.ui_to_qte_on();
          
        }
    }

    void look_prop(GameObject gameObject_name)
    {
        mood_value -= mood_value_remove;
        Destroy(gameObject_name);
        gameObject_name.GetComponent<prop_rule_manger>().prop_lose();
    }

}
