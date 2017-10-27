using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class unity_event_test : MonoBehaviour {

    public UnityEvent aaa;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        print(Time.time);
        aaa.Invoke();
	}

    public void bbbb()
    {
        print(Time.time);
    }
}
