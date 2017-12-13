using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prop_rule_manger : MonoBehaviour {

    [Header("道具實行方案")]

    public hand_tough_manger_2 hand_tough_manger_;

    public prop_manger prop_manger_;

    //prop_id腳本
    [Header("prop_id腳本")]
    public prop_id prop_id;

    //camera_z_ray腳本點擊位置
    [Header("camera_z_ray腳本點擊位置")]
    public Vector3 camera_z_vec3;

    //道具放置時間
    [Header("道具放置時間")]
    public float prop_mode_time;

    //道具放置第一次位置
    [Header("道具放置第一次位置")]
    public Vector3 prop_mode_vec3;

    [Header("--------------------")]

    [Header("長按部分")]

    //長按盲區
    [Header("長按盲區")]
    [Range(0f, 10f)]
    public float prop_press_dead = 3f;
    //[Header("陷阱腳本")]
    //public trap _tarp;

    //成功更換得材質球
    //[Header("長按或延遲 成功更換得材質球" + "  " + "原本為完全透明材質球")]
    //[Header("原本為完全透明材質球")]
    //public Material change_material;
    [Header("材質球和刪除的規則，長按延遲")]
    public prop_material_des _prop_material_des;
    [Header("事件執行")]
    public event_trigger_script[] _event_Trigger_Script;

    private void Awake()
    {
        hand_tough_manger_ = (hand_tough_manger_2)FindObjectOfType(typeof(hand_tough_manger_2));
        prop_manger_ = (prop_manger)FindObjectOfType(typeof(prop_manger));
        prop_id = (prop_id)FindObjectOfType(typeof(prop_id));

        prop_mode_time = prop_id.prop_time;

        prop_mode_vec3 = this.gameObject.transform.position;

        _prop_material_des = this.GetComponent<prop_material_des>();

        //_event_Trigger_Script = this.GetComponent<event_trigger_script>();

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        camera_z_vec3 = prop_manger_.camera_ray_point_vec3;

        switch (prop_id.prop_string.ToString())
        {
            case "press":
                print("press");
                press_prop();
                break;
            case "click":
                print("click");
                click_prop();
                break;
            case "delay":
                print("delay");
                delay_prop();
                break;
            default:
                break;
        }
    }

    void press_prop()
    {
        if (Input.touchCount == 0)
        {
            prop_lose();
        }

        //長按道具，未超過盲區視為OK
        if (Vector3.Distance(prop_mode_vec3, camera_z_vec3) <= prop_press_dead)
        {
            print("長按道具OK");
            Debug.DrawLine(prop_mode_vec3, camera_z_vec3, Color.black);

            prop_mode_time -= Time.deltaTime;
            //時間到，生成道具，並關閉腳本
            if (prop_mode_time <= 0)
            {
                //GameObject.Instantiate(prop_gameobject, prop_mode_vec3, Quaternion.identity);
                //prop_end();
                //this.gameObject.GetComponent<Renderer>().material = change_material;

                //prop_vec3_manger.prop_end();
                prop_manger_.prop_end();
                //_tarp.enabled = true;
                //Destroy(this.transform.GetChild(0).gameObject);

                _prop_material_des.prop_ok();
                //_event_Trigger_Script.start = true;
                Destroy(this);

            }

        }
        else if (Vector3.Distance(prop_mode_vec3, camera_z_vec3) > prop_press_dead)
        {
            print("長按道具NO");
            Debug.DrawLine(prop_mode_vec3, camera_z_vec3, Color.red);

            //prop_mode_vec3 = camera_z_vec3;

            //prop_mode_time = prop_gameobject.GetComponent<prop_id>().prop_time;

            //超過盲區取消到鎖，重新定位
            //is_first_prop_ok = false;

            prop_lose();

        }
    }

    void click_prop()
    {
        //prop_vec3_manger.prop_end();
        prop_manger_.prop_end();
        //_event_Trigger_Script.start = true;
        Destroy(this);
    }

    void delay_prop()
    {
        prop_mode_time -= Time.deltaTime;

        if (prop_mode_time <= 0)
        {
            //this.gameObject.GetComponent<Renderer>().material = change_material;
            //prop_vec3_manger.prop_end();
            _prop_material_des.prop_ok();
            prop_manger_.prop_end();
            //_event_Trigger_Script.start = true;
            Destroy(this);
        }
    }

    void prop_lose()
    {
        prop_manger_.is_first_prop_ok = false;
        //Destroy(this.transform.parent.gameObject);
        _prop_material_des.prop_no();
    }

    void event_trigger_start()
    {
        for(int i = 0; i<_event_Trigger_Script.Length;i++)
        {
            _event_Trigger_Script[i].start = true;
        }
    }

}
