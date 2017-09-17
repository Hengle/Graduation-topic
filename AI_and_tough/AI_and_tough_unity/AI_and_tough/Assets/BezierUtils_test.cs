using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierUtils_test : MonoBehaviour {

    public Transform[] controlPoints;

    public BezierUtils _bezierUtils;

    public Vector3[] aaa;

    public GameObject tttt;

    public int num = 0;

    public bool iii;

    // Use this for initialization
    void Start () {
       aaa = _bezierUtils.GetBeizerList(controlPoints[0].transform.position, controlPoints[1].transform.position, controlPoints[2].transform.position,50);
    }
	
	// Update is called once per frame
	void Update () {
            tttt.transform.position = aaa[num];
        if(iii ==true)
        {
            num++;
            iii = false;
        }
           
	}
}
