using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerp_test : MonoBehaviour {

	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(0, 3, 0), 10f*Time.deltaTime);
    }
}
