using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTE_manger : MonoBehaviour {

    public Text target_fraction_text;

    public Text now_fraction_text;

    public GameObject target_rotation;

    public GameObject arrow_rotation;

    public arrow_trigger _arrow_trigger;

    public float target_rotation_speed_max;

    public float target_rotation_speed_min;

    public float target_rotation_speed;

    public float arrow_rotation_speed_max;

    public float arrow_rotation_speed_min;

    public float arrow_rotation_speed;

    public float add_fraction = 10;

    public float target_fraction;

    public float now_fraction;

    public int life = 3;

    public Text life_text;

    public Text button_text;

    public bool stop_;

    // Use this for initialization
    void Start () {
        target_rotation_speed = Random.Range(target_rotation_speed_min, target_rotation_speed_max);
        arrow_rotation_speed = Random.Range(arrow_rotation_speed_min, arrow_rotation_speed_max);
    }
	
	// Update is called once per frame
	void Update () {
        target_rotation.transform.rotation = Quaternion.Euler((target_rotation.transform.rotation.eulerAngles + new Vector3(0, 0, target_rotation_speed)));
        arrow_rotation.transform.rotation = Quaternion.Euler((arrow_rotation.transform.rotation.eulerAngles + new Vector3(0, 0, arrow_rotation_speed)));

        //if((Mathf.Abs( target_rotation_speed - arrow_rotation_speed) > -0.5f ) && (Mathf.Abs(target_rotation_speed - arrow_rotation_speed) < 0.5f))
        //{
        //    target_rotation_speed = Random.Range(target_rotation_speed_min, target_rotation_speed_max);
        //    arrow_rotation_speed = Random.Range(arrow_rotation_speed_min, arrow_rotation_speed_max);
        //}

        now_fraction_text.text = now_fraction + "分";

        target_fraction_text.text = target_fraction + "分";

        life_text.text = life.ToString();

    }

    public void stop()
    {
        if(stop_ == false)
        {
            target_rotation_speed = 0;
            arrow_rotation_speed = 0;

            if (_arrow_trigger.enemy == true)
            {
                now_fraction += add_fraction;
            }
            else
            {
                life--;
            }

            button_text.text = "start";
            stop_ = true;
        }
        else
        {
            target_rotation_speed = Random.Range(target_rotation_speed_min, target_rotation_speed_max);
            arrow_rotation_speed = Random.Range(arrow_rotation_speed_min, arrow_rotation_speed_max);
            button_text.text = "stop";
            stop_ = false;
        }
      

    }
}
