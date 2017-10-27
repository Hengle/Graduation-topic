using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow_trigger : MonoBehaviour {

    public bool enemy = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name + "OnTriggerEnter2D");
    }


    //private void OnCollisionEnter2D(Collision2D collision2)
    //{
    //    print(collision2.gameObject.name + "OnCollisionEnter2D");
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        //print(collision.gameObject.name + "OnTriggerStay2D");
        enemy = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemy = false;
    }
}
