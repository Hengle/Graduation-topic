using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_event_manger : MonoBehaviour {

    public List<string> event_name_id;

    public List<GameObject> event_game;

    public Dictionary<string, GameObject> evnet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void event_ID(string name)
    {
        //print(name);
    }

}
