using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_test : MonoBehaviour {

    public Animator aaa;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(aaa.GetCurrentAnimatorStateInfo(0).IsName("test1") == true)
        {
            print("test1");
        }

	}
}
