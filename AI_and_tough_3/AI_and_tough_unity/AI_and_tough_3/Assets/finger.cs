using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finger : MonoBehaviour {

    [Header(" ID = finger")]

    public AI_gameobject_all _AI_gameobject_all;

    public event_name _event_name;

    public static string ID = "finger";

    public GameObject look_gameObject;

    private void Awake()
    {
        _AI_gameobject_all = this.GetComponent<AI_gameobject_all>();
        _event_name = this.GetComponent<event_name>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void finger_on()
    {
        if (_event_name._AI_look_event_manger_event_name != ID)
        {
            return;
        }

        look_gameObject = _event_name._AI_look_event_manger_event_gameObject;

        look_gameObject.GetComponent<press_look_boob>().look_boob();

    }
}
