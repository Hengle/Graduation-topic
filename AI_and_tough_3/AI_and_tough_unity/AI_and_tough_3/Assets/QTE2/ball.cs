using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

    public Vector3 vec3;

    public float speed = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += vec3.normalized * speed;
	}
}
