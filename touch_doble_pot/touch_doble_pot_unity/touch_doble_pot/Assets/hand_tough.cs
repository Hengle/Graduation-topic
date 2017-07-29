using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand_tough : MonoBehaviour {

    //public enum gesture {left,right,up,down }

    public GameObject point;

    public GameObject camera_gam;

    public Vector2 one_first_finger_pos = new Vector2();

    public Vector2 one_first_finger_displacement = new Vector2();

    public float move_dead = 50f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        mobile_input();
    }

    void mobile_input()
    {
        //手指未觸碰
        if(Input.touchCount <=0)
        {
            return;
        }

        //手指為一根時
        if(Input.touchCount == 1)
        {
            print("一根");

            //開始觸碰
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                print("點擊");
                //print(Input.touches[0].position + " " + Input.touches[0].deltaPosition);
                //Input.touches[0].position ==> 手指位置  Input.touches[0].deltaPosition ==>手指移動位置(手指位移方位)
                one_first_finger_pos = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Moved)//移動
            {

            }


            //手指離開螢幕
            if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {

            }



        }
        else if (Input.touchCount >= 2)//手指2根時
        {
            print("二根");
        }
    }

}
