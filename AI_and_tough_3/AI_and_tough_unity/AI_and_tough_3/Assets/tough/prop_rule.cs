using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prop_rule : MonoBehaviour {

    [Header("�D������")]

    //camera_z_ray�}��
    [Header("camera_z_ray�}��")]
    public camera_z_ray camera_z_ray;

    //prop_vec3_manger�}��
    [Header("prop_vec3_manger�}��")]
    public prop_vec3_manger prop_vec3_manger;

    //prop_id�}��
    [Header("prop_id�}��")]
    public prop_id prop_id;

    //camera_z_ray�}���I����m
    [Header("camera_z_ray�}���I����m")]
    public Vector3 camera_z_vec3;

    //�D���m�ɶ�
    [Header("�D���m�ɶ�")]
    public float prop_mode_time;

    //�D���m�Ĥ@����m
    [Header("�D���m�Ĥ@����m")]
    public Vector3 prop_mode_vec3;

    [Header("--------------------")]

    [Header("��������")]

    //��������
    [Header("��������")]
    [Range(0f, 10f)]
    public float prop_press_dead = 3f;

    //�������\�󴫱o����y
    //[Header("�������\�󴫱o����y")]
    //[Header("�쥻�������z������y")]
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
    //       //�����D��A���W�L���ϵ���OK
    //       if (Vector3.Distance(prop_mode_vec3, camera_z_vec3) <= prop_press_dead)
    //       {
    //           print("�����D��OK");
    //           Debug.DrawLine(prop_mode_vec3, camera_z_vec3, Color.black);

    //           prop_mode_time -= Time.deltaTime;
    //           //�ɶ���A�ͦ��D��A�������}��
    //           if (prop_mode_time <= 0)
    //           {
    //               //GameObject.Instantiate(prop_gameobject, prop_mode_vec3, Quaternion.identity);
    //               //prop_end();
    //               this.gameObject.GetComponent<Renderer>().material = press_change_material;
    //           }

    //       }
    //       else if (Vector3.Distance(prop_mode_vec3, camera_z_vec3) > prop_press_dead)
    //       {
    //           print("�����D��NO");
    //           Debug.DrawLine(prop_mode_vec3, camera_z_vec3, Color.red);

    //           //prop_mode_vec3 = camera_z_vec3;

    //           //prop_mode_time = prop_gameobject.GetComponent<prop_id>().prop_time;

    //           //�W�L���Ϩ�������A���s�w��
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
