using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line_test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(this.transform.position, transform.rotation * (Vector3.forward * 10), Color.cyan);
	}
}
