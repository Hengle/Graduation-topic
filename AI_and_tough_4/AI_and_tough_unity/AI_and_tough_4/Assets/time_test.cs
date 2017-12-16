using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time_test : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
		
	}

    private void Update()
    {
        print("Update");
    }

    private void FixedUpdate()
    {
        print("FixedUpdate");
    }

    private void LateUpdate()
    {
        print("LateUpdate");
    }

    void OnEnable()
    {
        //時間暫停
        Time.timeScale = 0f;

    }

    void OnDisable()
    {
        //時間以正常速度運行
        Time.timeScale = 1f;
    }
}
