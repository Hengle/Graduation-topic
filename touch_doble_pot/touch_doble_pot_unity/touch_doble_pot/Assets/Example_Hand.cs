using UnityEngine;
using System.Collections;
public class gDefine
{

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}

public class Example_Hand : MonoBehaviour
{

    //紀錄手指觸碰位置
    private Vector2 m_screenPos = new Vector2();

    void Update()
    {
        MobileInput();
        //#if UNITY_EDITOR || UNITY_STANDALONE
        //        MouseInput();   // 滑鼠偵測
        //#elif UNITY_ANDROID
        //		MobileInput();  // 觸碰偵測
        //#endif
    }

    //    Unity 触屏操作
    //当将Unity游戏运行到IOS或Android设备上时，桌面系统的鼠标左键可以自动变为手机屏幕上的触屏操作，但如多点触屏等操作却是无法利用鼠标操作进行的。Unity的Input类中不仅包含桌面系统的各种输入功能，也包含了针对移动设备触屏操作的各种功能，下面介绍一下Input类在触碰操作上的使用。
    //首先介绍一下Input.touches结构，这是一个触摸数组，每个记录代表着手指在屏幕上的触碰状态。每个手指触控都是通过Input.touches来描述的：
  
    //fingerId，触摸的唯一索引
    //position，触摸屏幕的位置
    //deltatime，从最后状态到目前状态所经过的时间
    //tapCount，点击数。Andorid设备不对点击计数，这个方法总是返回1
    //deltaPosition，自最后一帧所改变的屏幕位置
    //phase，相位，也即屏幕操作状态

    //其中phase（状态）有以下这几种：
    //Began，手指刚刚触摸屏幕
    //Moved，手指在屏幕上移动
    //Stationary，手指触摸屏幕，但自最后一阵没有移动
    //Ended，手指离开屏幕
    //Canceled，系统取消触控跟踪，原因如把设备放在脸上或同时超过5个触摸点




    void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_screenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            gDefine.Direction mDirection = HandDirection(m_screenPos, pos);
            Debug.Log("mDirection: " + mDirection.ToString());
        }
    }

    void MobileInput()
    {
        if (Input.touchCount <= 0)
            return;

        //1個手指觸碰螢幕
        if (Input.touchCount == 1)
        {

            //開始觸碰
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Debug.Log("Began");
                //紀錄觸碰位置
                m_screenPos = Input.touches[0].position;

                //手指移動
            }
            else if (Input.touches[0].phase == TouchPhase.Moved)
            {
                Debug.Log("Moved");
                //移動攝影機
                Camera.main.transform.Translate(new Vector3(-Input.touches[0].deltaPosition.x * Time.deltaTime, -Input.touches[0].deltaPosition.y * Time.deltaTime, 0));
            }


            //手指離開螢幕
            if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                Debug.Log("Ended");
                Vector2 pos = Input.touches[0].position;

                gDefine.Direction mDirection = HandDirection(m_screenPos, pos);
                Debug.Log("mDirection: " + mDirection.ToString());
            }
            //攝影機縮放，如果1個手指以上觸碰螢幕
        }
        else if (Input.touchCount > 1)
        {

            //記錄兩個手指位置
            Vector2 finger1 = new Vector2();
            Vector2 finger2 = new Vector2();

            //記錄兩個手指移動距離
            Vector2 move1 = new Vector2();
            Vector2 move2 = new Vector2();

            //是否是小於2點觸碰
            for (int i = 0; i < 2; i++)
            {
                UnityEngine.Touch touch = UnityEngine.Input.touches[i];
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
                        }
                        else
                        {
                            move = move2.x;
                        }

                        //取最大Y，並與取出的X累加
                        if (finger1.y > finger2.y)
                        {
                            move += move1.y;
                        }
                        else
                        {
                            move += move2.y;
                        }

                        //當兩指距離越遠，Z位置加的越多，相反之
                        Camera.main.transform.Translate(0, 0, move * Time.deltaTime);
                    }
                }
            }//end for
        }//end else if 
    }//end void

    gDefine.Direction HandDirection(Vector2 StartPos, Vector2 EndPos)
    {
        gDefine.Direction mDirection;

        //手指水平移動
        if (Mathf.Abs(StartPos.x - EndPos.x) > Mathf.Abs(StartPos.y - EndPos.y))
        {
            if (StartPos.x > EndPos.x)
            {
                //手指向左滑動
                mDirection = gDefine.Direction.Left;
            }
            else
            {
                //手指向右滑動
                mDirection = gDefine.Direction.Right;
            }
        }
        else
        {
            if (m_screenPos.y > EndPos.y)
            {
                //手指向下滑動
                mDirection = gDefine.Direction.Down;
            }
            else
            {
                //手指向上滑動
                mDirection = gDefine.Direction.Up;
            }
        }
        return mDirection;
    }
}