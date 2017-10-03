using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_prop : MonoBehaviour {

    public GameObject aaa;

    public test_prop test_prop_;

    public GameObject this_gameo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject.Instantiate(aaa);
	}

    public void aaa_test()
    {
        test_prop_.aaa = this_gameo;
    }

}
