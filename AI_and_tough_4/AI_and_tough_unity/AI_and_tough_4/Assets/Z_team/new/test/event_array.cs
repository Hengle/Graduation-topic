using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class event_array : MonoBehaviour {

   public UnityEvent event_event;

    public int i;

	// Use this for initialization
	void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {

        event_event.Invoke();

    }

    public void next()
    {
        i++;
    }
}
