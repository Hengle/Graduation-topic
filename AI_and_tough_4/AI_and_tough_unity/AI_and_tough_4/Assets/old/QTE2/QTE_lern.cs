using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE_lern : MonoBehaviour
{

    public AnimationCurve[] target_lern_basic;

    //public AnimationCurve[] target_lern_difficult;

    //public AnimationCurve[] target_lern_Premium;

    //public float time;

    public int i;

    public GameObject target;

    public float target_num;

    public float long_y;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //print(target_lern_basic[1].Evaluate(time));
        target.transform.localPosition = new Vector3(0, long_y + ( target_lern_basic[i].Evaluate(Time.time)) * target_num, 0);
    }
}
