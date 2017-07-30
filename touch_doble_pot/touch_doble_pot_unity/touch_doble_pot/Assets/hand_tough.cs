using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand_tough : MonoBehaviour
{

    //public enum gesture {left,right,up,down }
    
    //point物件
    [Header("point物件(攝影機父物件)")]
    public GameObject point;

    //攝影機
    [Header("攝影機")]
    public GameObject camera_gam;

    //移動速度
    [Header("移動速度")]
    [Range(0f, 100f)]
    public float move_speed = 10f;

    //移動速度
    [Header("旋轉速度")]
    [Range(0f, 200f)]
    public float rotate_speed = 100f;

    //第一根手指位置
    [Header("第一根手指位置")]
    public Vector2 one_finger_pos = new Vector2();

    //第一根手指位移
    [Header("第一根手指位移")]
    public Vector2 one_finger_displacement = new Vector2();

    //盲區
    [Header("盲區")]
    [Range(0f, 100f)]
    public float move_dead = 50f;

    //移動point或攝影機
    [Header("移動point或攝影機")]
    public bool move_point = false;

    //第一次點擊
    [Header("第一次點擊")]
    public bool first_chack = false;

    //時間
    [Header("時間")]
    public float move_point_time = 0f;

    //最大時間
    [Header("最大時間")]
    [Range(0f, 10f)]
    public float move_point_time_max = 1f;

    // Use this for initialization
    void Start()
    {
        move_point_time = move_point_time_max;

    }

    //public float x, y, z;

    // Update is called once per frame
    void Update()
    {
        mobile_input();
        //point.transform.Rotate(x,y,z, Space.World);
        //point.transform.rotation = Quaternion.Euler(x, y, z);
    }

    void mobile_input()
    {
        //手指未觸碰
        if (Input.touchCount <= 0)
        {
            return;
        }

        //手指為一根時
        if (Input.touchCount == 1)
        {
            print("一根");

            //開始觸碰
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                print("點擊");
                //print(Input.touches[0].position + " " + Input.touches[0].deltaPosition);
                //Input.touches[0].position ==> 手指位置  Input.touches[0].deltaPosition ==>手指移動位置(手指位移方位)
                one_finger_pos = Input.touches[0].position;
                first_chack = true;
            }
            else if ((Input.touches[0].phase == TouchPhase.Stationary) && (first_chack == true))//觸碰不移動
            {
                print("停留");
                time_move_point();
            }
            else if (Input.touches[0].phase == TouchPhase.Moved)//移動
            {
                print("移動");

                print(Input.touches[0].position + " " + Input.touches[0].deltaPosition);

                first_chack = false;

                one_finger_displacement = Input.touches[0].deltaPosition.normalized;

                if (move_point == true)
                {
                    point.transform.Translate(
                        new Vector3(
                            -one_finger_displacement.x * move_speed * Time.deltaTime,
                            0,
                            -one_finger_displacement.y * move_speed * Time.deltaTime),
                        Space.World);
                    //Translate(Vector3,  Space.World) 以世界座標軸移動
                }
                else if (move_point == false)
                {
                    //point.transform.Rotate(
                    //    one_finger_displacement.y * speed * Time.deltaTime,
                    //        one_finger_displacement.x * speed * Time.deltaTime,
                    //        0,
                    //    Space.World);

                    if (Mathf.Abs(one_finger_displacement.x) > Mathf.Abs(one_finger_displacement.y))
                    {
                        //point.transform.Rotate(0, one_finger_displacement.x * rotate_speed * Time.deltaTime, 0, Space.World);
                        point.transform.rotation = Quaternion.Euler(
                            point.transform.rotation.eulerAngles.x,
                            point.transform.rotation.eulerAngles.y + one_finger_displacement.x * rotate_speed * Time.deltaTime,
                            0);
                    }
                    else if (Mathf.Abs(one_finger_displacement.x) < Mathf.Abs(one_finger_displacement.y))
                    {
                        //point.transform.Rotate(one_finger_displacement.y * rotate_speed * Time.deltaTime, 0, 0, Space.World);
                        point.transform.rotation = Quaternion.Euler(
                            point.transform.rotation.eulerAngles.x + one_finger_displacement.y * rotate_speed * Time.deltaTime,
                            point.transform.rotation.eulerAngles.y, 
                            0);
                    }


                }
            }



            //手指離開螢幕
            if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                move_point_time = move_point_time_max;
                move_point = false;
                first_chack = false;
            }



        }
        else if (Input.touchCount >= 2)//手指2根時
        {
            print("二根");
        }
    }


    void time_move_point()
    {
        if(move_point_time <= move_point_time_max)
        {
            move_point_time -= Time.deltaTime;
            if(move_point_time <= 0)
            {
                move_point_time = move_point_time_max;
                move_point = true;
                first_chack = false;
            }
        }
    }

}
