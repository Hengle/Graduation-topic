using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class press_look_boob : MonoBehaviour {

    public GameObject parent;

    public GameObject boob;

    public prop_manger _prop_manger;

    private void Awake()
    {
        parent = this.gameObject.transform.parent.gameObject;
        _prop_manger = FindObjectOfType<prop_manger>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void look_boob()
    {
        _prop_manger.prop_end();
        GameObject.Instantiate(boob, this.gameObject.transform.position, Quaternion.identity);
        Destroy(parent.gameObject);
        //Destroy(this.gameObject);
    }

}
