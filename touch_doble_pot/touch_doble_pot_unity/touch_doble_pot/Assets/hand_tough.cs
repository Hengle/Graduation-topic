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

    //攝影機最遠位置
    [Header("攝影機最遠位置")]
    [Range(0f,50f)]
    public float camera_up = 20f;

    //攝影機最近位置
    [Header("攝影機最近位置")]
    [Range( 0f,50f)]
    public float camera_down = 10f;

    //攝影機原始位置
    [Header("攝影機原始位置")]
    public Vector3 camera_reduction_vec3;

    //攝影機父物件原始位置
    [Header("攝影機父物件原始位置")]
    public Vector3 point_reduction_vec3;

    //攝影機原始旋轉
    [Header("攝影機原始旋轉")]
    public Quaternion camera_reduction_quater;

    //攝影機父物件原始旋轉
    [Header("攝影機父物件原始旋轉")]
    public Quaternion point_reduction_quater;

    //還原開關待刪除
    [Header("還原開關待刪除")]
    public bool reduction = false;

    // Use this for initialization
    void Start()
    {
        move_point_time = move_point_time_max;

        point_reduction_vec3 = point.transform.position;
        point_reduction_quater = point.transform.rotation;

        camera_reduction_vec3 = camera_gam.transform.position;
        camera_reduction_quater = camera_gam.transform.rotation;

    }

    //public float x, y, z;

    // Update is called once per frame
    void Update()
    {
        mobile_input();
        //point.transform.Rotate(x,y,z, Space.World);
        //point.transform.rotation = Quaternion.Euler(x, y, z);

        //還原待刪除
        if(reduction == true)
        {
            point_camera_reduction();
            reduction = false;
        }
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
                print("一根點擊");
                //print(Input.touches[0].position + " " + Input.touches[0].deltaPosition);
                //Input.touches[0].position ==> 手指位置  Input.touches[0].deltaPosition ==>手指移動位置(手指位移方位)
                one_finger_pos = Input.touches[0].position;
                first_chack = true;
            }
            else if ((Input.touches[0].phase == TouchPhase.Stationary) && (first_chack == true))//觸碰不移動
            {
                print("一根停留");
                time_move_point();
            }
            else if (Input.touches[0].phase == TouchPhase.Moved)//移動
            {
                print("一根移動");

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

            //記錄兩個手指位置
            Vector2 finger1 = new Vector2();
            Vector2 finger2 = new Vector2();

            //記錄兩個手指移動距離
            Vector2 move1 = new Vector2();
            Vector2 move2 = new Vector2();

            //是否是小於2點觸碰
            for (int i = 0; i < 2; i++)
            {
                Touch touch = Input.touches[i];
                //Input.touches 触摸列表 static var touches : Touch[]



                if (touch.phase == TouchPhase.Ended)
                    break;

                if (touch.phase == TouchPhase.Moved)
                {
                    //每次都重置
                    float move = 0;

                    //觸碰一點
                    if (i == 0)
                    {
                        finger1 = touch.position;
                        move1 = touch.deltaPosition;
                        //另一點
                    }
                    else
                    {
                        finger2 = touch.position;
                        move2 = touch.deltaPosition;

                        //取最大X
                        if (finger1.x > finger2.x)
                        {
                            move = move1.x;
                            //print(move);
                        }
                        else
                        {
                            move = move2.x;
                            //print(move);
                        }

                        //取最大Y，並與取出的X累加
                        if (finger1.y > finger2.y)
                        {
                            move += move1.y;
                            //print(move);
                        }
                        else
                        {
                            move += move2.y;
                            //print(move);
                        }

                        //只拿取最大點的位移，例X最大點位移為正就放大，負為縮

                        //print(finger1 + " " + finger2 + " " + move1 + " " + move2 + " " + move);
                        //當兩指距離越遠，Z位置加的越多，相反之
                        //Camera.main.transform.Translate(0, 0, move * Time.deltaTime);

                        if ((Vector3.Distance(point.transform.position , camera_gam.transform.position) - move * Time.deltaTime >= camera_down) && (Vector3.Distance(point.transform.position, camera_gam.transform.position) - move* Time.deltaTime <= camera_up))
                        {
                            camera_gam.transform.Translate(0, 0, move * Time.deltaTime);
                        }
                        //else
                        //{
                        //    if (move > 0)
                        //    {
                        //        camera_gam.transform.position = new Vector3(
                        //            camera_gam.transform.position.x,
                        //            camera_gam.transform.position.y,
                        //            camera_down);
                        //    }
                        //    else
                        //    {
                        //        camera_gam.transform.position = new Vector3(
                        //            camera_gam.transform.position.x,
                        //            camera_gam.transform.position.y,
                        //            camera_up);
                        //    }
                        //}

                    }
                }

            }
        }
    }

    void time_move_point()
    {
        if (move_point_time <= move_point_time_max)
        {
            move_point_time -= Time.deltaTime;
            if (move_point_time <= 0)
            {
                move_point_time = move_point_time_max;
                move_point = true;
                first_chack = false;
            }
        }
    }

    void point_camera_reduction()
    {
        point.transform.position = point_reduction_vec3;
        point.transform.rotation = point_reduction_quater;

        camera_gam.transform.position = camera_reduction_vec3;
        camera_gam.transform.rotation = camera_reduction_quater;

    }

}
