using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prop_vec3_manger : MonoBehaviour
{

    [Header("道具與其他腳本控管")]
    [Header("---------------------------------")]

    //camera_z_ray腳本
    [Header("camera_z_ray腳本")]
    public camera_z_ray camera_z_ray;

    //camera_z_ray腳本點擊位置
    [Header("camera_z_ray腳本點擊位置")]
    public Vector3 camera_z_vec3;

    //傳輸過來的道具
    [Header("傳輸過來的道具")]
    public GameObject prop_gameobject;

    [Header("道具使用中")]
    [Header("---------------------------------")]

    //道具是否使用
    [Header("道具是否使用")]
    public bool is_first_prop_ok = false;

    //道具放置方式
    [Header("道具放置方式")]
    public string prop_mode;

    //道具放置時間
    [Header("道具放置時間")]
    public float prop_mode_time;

    //道具放置第一次位置
    [Header("道具放置第一次位置")]
    public Vector3 prop_mode_vec3;

    private void Awake()
    {
        camera_z_ray = (camera_z_ray)FindObjectOfType(typeof(camera_z_ray));
    }

    // Use this for initialization
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //camera_z_vec3 = camera_z.camera_ray_point_vec3;

        if (Input.touchCount == 0)
        {
            return;
        }
        else
        {
            if(is_first_prop_ok == false)
            {
                prop_chack();
            }
            else if (is_first_prop_ok == true)
            {

            }
        }

      
    }

    public void prop_gameobject_send(GameObject gameobject_name)
    {
        if(is_first_prop_ok ==true)
        {
            return;
        }
        else if (is_first_prop_ok == false)
        {
            prop_gameobject = gameobject_name;
        }
    }

    void prop_chack()
    {
        prop_mode = prop_gameobject.GetComponent<prop_id>().prop_string.ToString();
        prop_mode_time = prop_gameobject.GetComponent<prop_id>().prop_time;
        prop_mode_vec3 = camera_z_vec3;


    }




}
