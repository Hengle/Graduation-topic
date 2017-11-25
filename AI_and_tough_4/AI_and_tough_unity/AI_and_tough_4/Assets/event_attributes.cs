using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event_attributes : MonoBehaviour {

    [Header("飢餓值")]
    public float hunger_value;
    [Header("心情值")]
    public float mood_value;
    [Header("入侵度")]
    public float Invasion_value;

    public float hunger_value_remove_sec;

    public float mood_value_remove;

    public float Invasion_value_add;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
