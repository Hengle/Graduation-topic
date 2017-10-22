using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prop_rule : MonoBehaviour {

    [Header("道具實行方案")]

    //camera_z_ray腳本
    [Header("camera_z_ray腳本")]
    public camera_z_ray camera_z_ray;

    //prop_vec3_manger腳本
    [Header("prop_vec3_manger腳本")]
    public prop_vec3_manger prop_vec3_manger;

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

    //長按成功更換得材質球
    //[Header("長按成功更換得材質球")]
    //[Header("原本為完全透明材質球")]
    //public Material press_change_material;

    //   private void Awake()
    //   {
    //       camera_z_ray = (camera_z_ray)FindObjectOfType(typeof(camera_z_ray));
    //       prop_vec3_manger = (prop_vec3_manger)FindObjectOfType(typeof(prop_vec3_manger));
    //       prop_id = (prop_id)FindObjectOfType(typeof(prop_id));

    //       prop_mode_time = prop_id.prop_time;

    //       prop_mode_vec3 = this.gameObject.transform.position;

    //   }

    //   // Use this for initialization
    //   void Start () {

    //}

    //// Update is called once per frame
    //void Update ()
    //   {
    //       camera_z_vec3 = camera_z_ray.camera_ray_point_vec3;

    //       switch (prop_id.prop_string.ToString())
    //       {
    //           case "press":
    //               print("press");
    //               press_prop();
    //               break;
    //           case "click":
    //               print("click");
    //               click_prop();
    //               break;
    //           case "delay":
    //               print("delay");
    //               delay_prop();
    //               break;
    //           default:
    //               break;
    //       }

    //   }

    //   void press_prop()
    //   {
    //       //長按道具，未超過盲區視為OK
    //       if (Vector3.Distance(prop_mode_vec3, camera_z_vec3) <= prop_press_dead)
    //       {
    //           print("長按道具OK");
    //           Debug.DrawLine(prop_mode_vec3, camera_z_vec3, Color.black);

    //           prop_mode_time -= Time.deltaTime;
    //           //時間到，生成道具，並關閉腳本
    //           if (prop_mode_time <= 0)
    //           {
    //               //GameObject.Instantiate(prop_gameobject, prop_mode_vec3, Quaternion.identity);
    //               //prop_end();
    //               this.gameObject.GetComponent<Renderer>().material = press_change_material;
    //           }

    //       }
    //       else if (Vector3.Distance(prop_mode_vec3, camera_z_vec3) > prop_press_dead)
    //       {
    //           print("長按道具NO");
    //           Debug.DrawLine(prop_mode_vec3, camera_z_vec3, Color.red);

    //           //prop_mode_vec3 = camera_z_vec3;

    //           //prop_mode_time = prop_gameobject.GetComponent<prop_id>().prop_time;

    //           //超過盲區取消到鎖，重新定位
    //           //is_first_prop_ok = false;

    //           prop_lose();

    //       }
    //   }

    //   void click_prop()
    //   {

    //   }

    //   void delay_prop()
    //   {

    //   }

    //   void prop_lose()
    //   {
    //       prop_vec3_manger.is_first_prop_ok = false;
    //       Destroy(this.gameObject);
    //   }

    //   void prop_ok()
    //   {

    //   }

}
