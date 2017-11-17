using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE_target_z : MonoBehaviour {

    public AnimationCurve[] target_z_lern_basic;

    public int i;

    public GameObject target;

    public float target_num;

    public Quaternion angle;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //target.transform.localRotation = new Vector3(0,0, (target_z_lern_basic[i].Evaluate(Time.time)) * target_num);
        angle.eulerAngles = new Vector3(0, 0, (target_z_lern_basic[i].Evaluate(Time.time) - 0.5f) * target_num);
        target.transform.localRotation = angle;

    }
}
