using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE_raotation_test : MonoBehaviour {

    public GameObject target_rotation;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        target_rotation.transform.rotation = Quaternion.Euler((target_rotation.transform.rotation.eulerAngles + new Vector3(0, 0, 1)));
    }
}
