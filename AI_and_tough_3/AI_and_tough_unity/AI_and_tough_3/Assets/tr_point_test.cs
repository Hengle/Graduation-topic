using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tr_point_test : MonoBehaviour {

    public Vector3 aaa;

    public float aaaaa;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //this.transform.TransformPoint(aaa);
        //this.transform.Translate(aaa);

        this.transform.position = Vector3.Lerp(this.transform.position, aaa, aaaaa);
	}
}
