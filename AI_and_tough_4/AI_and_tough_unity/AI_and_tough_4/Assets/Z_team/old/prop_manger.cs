using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prop_manger : MonoBehaviour
{

    [Header("道具與其他腳本控管")]
    [Header("---------------------------------")]

    public LayerMask ray_layer;

    //傳輸過來的道具
    [Header("傳輸過來的道具")]
    public GameObject prop_gameobject;

    //傳輸過來的UI
    [Header("傳輸過來的UI")]
    public GameObject ui_gameobject;

    [Header("道具使用中")]
    [Header("---------------------------------")]

    //道具是否使用
    [Header("道具是否使用")]
    public bool is_first_prop_ok = false;

    //攝影機Ray-----------------------------------
    [Header("-----------------攝影機Ray------------------")]

    //攝影機組件
    [Header("攝影機組件")]
    public Camera camera_ray;

    //攝影機Ray位置
    [Header("攝影機Ray位置")]
    public Vector3 camera_ray_point_vec3;

    ////透明物件，用以讓怪物視野偵測
    //[Header("透明物件，用以讓怪物視野偵測")]
    //public GameObject transparent_game;

    //UI死區
    [Header("UI死區")]
    public GameObject[] dead_ui;

    //腳本開關
    [Header("腳本是否關閉")]
    public bool script_close = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //print(dead_tough(dead_ui, Input.touches[0].position));
        if (script_close == false)
        {
            if (Input.touchCount == 0)
            {
                //transparent_game.transform.position = new Vector3(999, 0, 0);
                return;
            }
            else
            {
                if (dead_tough(dead_ui, Input.touches[0].position) == false)
                {
                    camera_z_ray_function();
                }

                if ((is_first_prop_ok == false) && (dead_tough(dead_ui, Input.touches[0].position) == false))
                {
                    GameObject.Instantiate(prop_gameobject, camera_ray_point_vec3, Quaternion.identity,this.transform);
                    is_first_prop_ok = true;
                }
                else if (is_first_prop_ok == true)
                {
                    return;
                }
            }
        }
    }

    /// <summary>
    /// UI 專用 用於輸入道具資料
    /// </summary>
    /// <param name="prop_name">道具物件</param>
    /// <param name="ui_name">按下UI物件</param>
    public void prop_gameobject_send(GameObject prop_name, GameObject ui_name)
    {
        if (is_first_prop_ok == true)
        {
            return;
        }
        else if (is_first_prop_ok == false)
        {
            prop_gameobject = prop_name;
            ui_gameobject = ui_name;
        }

        //prop_gameobject = prop_name;
        //ui_gameobject = ui_name;
    }

    /// <summary>
    /// 攝影機點擊位置(對方需要 Colider)
    /// </summary>
    void camera_z_ray_function()
    {
        Ray ray = camera_ray.ScreenPointToRay(Input.touches[0].position);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction);
        if (Physics.Raycast(ray, out hit, 999, /*1 << LayerMask.NameToLayer("ray")*/ray_layer.value)) 
        {
            //print(hit.collider.gameObject.name + hit.point);
            print(hit.point);
            camera_ray_point_vec3 = hit.point;
            //transparent_game.transform.position = hit.point;
            //cube.transform.position = hit.point;
        }
    }

    /// <summary>
    /// 初始化道具資訊
    /// </summary>
    public void prop_end()
    {
        //camera_z_ray.enabled = false;

        //this.enabled = false;

        //is_first_prop_ok = false;

        //ui_gameobject.GetComponent<Toggle>().isOn = false;

        //camera_z_ray.camera_ray_point_vec3 = new Vector3(0, 0, 0);

        //camera_z_vec3 = new Vector3(0, 0, 0);

        //prop_mode_vec3 = new Vector3(0, 0, 0);

        //prop_gameobject = null;

        //prop_mode_time = 0;

        //prop_mode = "";

        //ui_gameobject = null;

        //transparent_game.transform.position = new Vector3(999, 0, 0);
        //傳輸過來的道具

        ui_gameobject.GetComponent<Toggle>().isOn = false;

        ui_gameobject.GetComponent<Toggle>().GetComponent<Ui_toggle_id>().chack_on();

        prop_gameobject = null;

        ui_gameobject = null;

        is_first_prop_ok = false;

        camera_ray_point_vec3 = new Vector3(0, 0, 0);

    }

    bool dead_tough(GameObject[] dead_game, Vector3 input_pos)
    {
        bool anser = false;

        foreach (GameObject serch in dead_game)
        {
            GameObject point_1 = serch.transform.GetChild(0).gameObject;
            GameObject point_2 = serch.transform.GetChild(1).gameObject;

            if (((point_1.transform.position.x > input_pos.x) && (input_pos.x > point_2.transform.position.x)) &&
               ((point_1.transform.position.y > input_pos.y) && (input_pos.y > point_2.transform.position.y)))
            {
                anser = true;
            }
            else if (((point_1.transform.position.x > input_pos.x) && (input_pos.x > point_2.transform.position.x)) &&
               ((point_1.transform.position.y < input_pos.y) && (input_pos.y < point_2.transform.position.y)))
            {
                anser = true;
            }
            else if (((point_1.transform.position.x < input_pos.x) && (input_pos.x < point_2.transform.position.x)) &&
                   ((point_1.transform.position.y > input_pos.y) && (input_pos.y > point_2.transform.position.y)))
            {
                anser = true;
            }
            else if (((point_1.transform.position.x < input_pos.x) && (input_pos.x < point_2.transform.position.x)) &&
                    ((point_1.transform.position.y < input_pos.y) && (input_pos.y < point_2.transform.position.y)))
            {
                anser = true;
            }

        }

        return anser;
    }

    //[Header("道具與其他腳本控管")]
    //[Header("---------------------------------")]

    //public LayerMask ray_layer;

    ////傳輸過來的道具
    //[Header("傳輸過來的道具")]
    //public GameObject prop_gameobject;

    ////傳輸過來的UI
    //[Header("傳輸過來的UI")]
    //public GameObject ui_gameobject;

    //[Header("道具使用中")]
    //[Header("---------------------------------")]

    ////道具是否使用
    //[Header("道具是否使用")]
    //public bool is_first_prop_ok = false;

    ////攝影機Ray-----------------------------------
    //[Header("-----------------攝影機Ray------------------")]

    ////攝影機組件
    //[Header("攝影機組件")]
    //public Camera camera_ray;

    ////攝影機Ray位置
    //[Header("攝影機Ray位置")]
    //public Vector3 camera_ray_point_vec3;

    ////透明物件，用以讓怪物視野偵測
    //[Header("透明物件，用以讓怪物視野偵測")]
    //public GameObject transparent_game;

    ////UI死區
    //[Header("UI死區")]
    //public GameObject[] dead_ui;

    ////腳本開關
    //[Header("腳本是否關閉")]
    //public bool script_close = false;

    //// Use this for initialization
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //print(dead_tough(dead_ui, Input.touches[0].position));
    //    if (script_close == false)
    //    {
    //        if (Input.touchCount == 0)
    //        {
    //            transparent_game.transform.position = new Vector3(999, 0, 0);
    //            return;
    //        }
    //        else
    //        {
    //            if (dead_tough(dead_ui, Input.touches[0].position) == false)
    //            {
    //                camera_z_ray_function();
    //            }

    //            if ((is_first_prop_ok == false) && (dead_tough(dead_ui, Input.touches[0].position) == false))
    //            {
    //                GameObject.Instantiate(prop_gameobject, camera_ray_point_vec3, Quaternion.identity);
    //                is_first_prop_ok = true;
    //            }
    //            else if (is_first_prop_ok == true)
    //            {
    //                return;
    //            }
    //        }
    //    }
    //}

    ///// <summary>
    ///// UI 專用 用於輸入道具資料
    ///// </summary>
    ///// <param name="prop_name">道具物件</param>
    ///// <param name="ui_name">按下UI物件</param>
    //public void prop_gameobject_send(GameObject prop_name, GameObject ui_name)
    //{
    //    if (is_first_prop_ok == true)
    //    {
    //        return;
    //    }
    //    else if (is_first_prop_ok == false)
    //    {
    //        prop_gameobject = prop_name;
    //        ui_gameobject = ui_name;
    //    }

    //    //prop_gameobject = prop_name;
    //    //ui_gameobject = ui_name;
    //}

    ///// <summary>
    ///// 攝影機點擊位置(對方需要 Colider)
    ///// </summary>
    //void camera_z_ray_function()
    //{
    //    Ray ray = camera_ray.ScreenPointToRay(Input.touches[0].position);
    //    RaycastHit hit;
    //    Debug.DrawRay(ray.origin, ray.direction);
    //    if (Physics.Raycast(ray, out hit, 999, /*1 << LayerMask.NameToLayer("ray")*/ray_layer.value))
    //    {
    //        //print(hit.collider.gameObject.name + hit.point);
    //        print(hit.point);
    //        camera_ray_point_vec3 = hit.point;
    //        transparent_game.transform.position = hit.point;
    //        //cube.transform.position = hit.point;
    //    }
    //}

    ///// <summary>
    ///// 初始化道具資訊
    ///// </summary>
    //public void prop_end()
    //{
    //    //camera_z_ray.enabled = false;

    //    //this.enabled = false;

    //    //is_first_prop_ok = false;

    //    //ui_gameobject.GetComponent<Toggle>().isOn = false;

    //    //camera_z_ray.camera_ray_point_vec3 = new Vector3(0, 0, 0);

    //    //camera_z_vec3 = new Vector3(0, 0, 0);

    //    //prop_mode_vec3 = new Vector3(0, 0, 0);

    //    //prop_gameobject = null;

    //    //prop_mode_time = 0;

    //    //prop_mode = "";

    //    //ui_gameobject = null;

    //    transparent_game.transform.position = new Vector3(999, 0, 0);
    //    //傳輸過來的道具

    //    ui_gameobject.GetComponent<Toggle>().isOn = false;

    //    ui_gameobject.GetComponent<Toggle>().GetComponent<Ui_toggle_id>().chack_on();

    //    prop_gameobject = null;

    //    ui_gameobject = null;

    //    is_first_prop_ok = false;

    //    camera_ray_point_vec3 = new Vector3(0, 0, 0);

    //}

    //bool dead_tough(GameObject[] dead_game, Vector3 input_pos)
    //{
    //    bool anser = false;

    //    foreach (GameObject serch in dead_game)
    //    {
    //        GameObject point_1 = serch.transform.GetChild(0).gameObject;
    //        GameObject point_2 = serch.transform.GetChild(1).gameObject;

    //        if (((point_1.transform.position.x > input_pos.x) && (input_pos.x > point_2.transform.position.x)) &&
    //           ((point_1.transform.position.y > input_pos.y) && (input_pos.y > point_2.transform.position.y)))
    //        {
    //            anser = true;
    //        }
    //        else if (((point_1.transform.position.x > input_pos.x) && (input_pos.x > point_2.transform.position.x)) &&
    //           ((point_1.transform.position.y < input_pos.y) && (input_pos.y < point_2.transform.position.y)))
    //        {
    //            anser = true;
    //        }
    //        else if (((point_1.transform.position.x < input_pos.x) && (input_pos.x < point_2.transform.position.x)) &&
    //               ((point_1.transform.position.y > input_pos.y) && (input_pos.y > point_2.transform.position.y)))
    //        {
    //            anser = true;
    //        }
    //        else if (((point_1.transform.position.x < input_pos.x) && (input_pos.x < point_2.transform.position.x)) &&
    //                ((point_1.transform.position.y < input_pos.y) && (input_pos.y < point_2.transform.position.y)))
    //        {
    //            anser = true;
    //        }

    //    }

    //    return anser;
    //}


}
