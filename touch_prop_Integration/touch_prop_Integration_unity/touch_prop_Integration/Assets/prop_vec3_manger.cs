using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //傳輸過來的UI
    [Header("傳輸過來的UI")]
    public GameObject ui_gameobject;

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

    //延遲盲區
    [Header("延遲盲區")]
    [Range(0f, 10f)]
    public float prop_press_dead = 3f;

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
        camera_z_vec3 = camera_z_ray.camera_ray_point_vec3;

        if (Input.touchCount == 0)
        {
            return;
        }
        else
        {
            if (is_first_prop_ok == false)
            {
                //第一次按下，鎖住道具
                prop_chack();
            }
            else if (is_first_prop_ok == true)
            {
                switch (prop_mode)
                {
                    case "press":
                        print("press");
                        press_prop();
                        break;
                    case "click":
                        print("click");
                        click();
                        break;
                    case "delay":
                        print("delay");
                        delay();
                        break;
                    default:
                        break;
                }

            }
        }


    }

    /// <summary>
    /// UI 專用 用於輸入道具資料
    /// </summary>
    /// <param name="prop_name">道具物件</param>
    /// <param name="ui_name">按下UI物件</param>
    public void prop_gameobject_send(GameObject prop_name , GameObject ui_name)
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
    }

    /// <summary>
    /// 第一次使用，避免在使用時切換到其他道具，故鎖住
    /// </summary>
    void prop_chack()
    {
        //讀入 "道具放置方式" "放置方式時間"  "點下時座標"
        prop_mode = prop_gameobject.GetComponent<prop_id>().prop_string.ToString();
        prop_mode_time = prop_gameobject.GetComponent<prop_id>().prop_time;
        prop_mode_vec3 = camera_z_vec3;

        //鎖住道具
        is_first_prop_ok = true;
    }

    /// <summary>
    /// 長按道具
    /// </summary>
    void press_prop()
    {
        //長按道具，未超過盲區視為OK
        if (Vector3.Distance(prop_mode_vec3, camera_z_vec3) <= prop_press_dead) 
        {
            print("長按道具OK");
            Debug.DrawLine(prop_mode_vec3, camera_z_vec3,Color.black);

            prop_mode_time -= Time.deltaTime;
            //時間到，生成道具，並關閉腳本
            if(prop_mode_time <= 0)
            {
                GameObject.Instantiate(prop_gameobject,prop_mode_vec3,Quaternion.identity);
                prop_end();
            }

        }
        else if (Vector3.Distance(prop_mode_vec3, camera_z_vec3) > prop_press_dead)
        {
            print("長按道具NO");
            Debug.DrawLine(prop_mode_vec3, camera_z_vec3, Color.red);

            //prop_mode_vec3 = camera_z_vec3;

            //prop_mode_time = prop_gameobject.GetComponent<prop_id>().prop_time;
            
            //超過盲區取消到鎖，重新定位
            is_first_prop_ok = false;

        }
    }

    /// <summary>
    /// 直接生成道具
    /// </summary>
    void click()
    {
        GameObject.Instantiate(prop_gameobject, prop_mode_vec3, Quaternion.identity);
        prop_end();
    }

    //IEnumerator delay()
    //{
    //    GameObject.Instantiate(prop_gameobject, prop_mode_vec3, Quaternion.identity);
    //    prop_gameobject.GetComponent<Material>().color = new Color32(0, 0, 255, 125);
    //    yield return new WaitForSeconds(prop_mode_time);
    //    prop_gameobject.GetComponent<Material>().color = new Color32(0, 0, 255, 255);
    //    prop_end();
    //}

    /// <summary>
    /// 延遲道具，延遲腳本在道具上
    /// 所以這串無用待取消
    /// </summary>
    void delay()
    {
        GameObject.Instantiate(prop_gameobject, prop_mode_vec3, Quaternion.identity);
        prop_end();
    }

    /// <summary>
    /// 初始化道具資訊
    /// </summary>
    public void prop_end()
    {
        camera_z_ray.enabled = false;

        this.enabled = false;

        is_first_prop_ok = false;

        ui_gameobject.GetComponent<Toggle>().isOn = false;

        camera_z_ray.camera_ray_point_vec3 = new Vector3(0, 0, 0);

        camera_z_vec3 = new Vector3(0, 0, 0);

        prop_mode_vec3 = new Vector3(0, 0, 0);

        prop_gameobject = null;

        prop_mode_time = 0;

        prop_mode = "";

        ui_gameobject = null;

    }

}