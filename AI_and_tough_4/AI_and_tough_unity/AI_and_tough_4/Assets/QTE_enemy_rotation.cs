using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE_enemy_rotation : MonoBehaviour {

    public GameObject back;

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        back.transform.Rotate(new Vector3(0,0,speed));
	}
}
