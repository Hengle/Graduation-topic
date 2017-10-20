using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QTE_event : MonoBehaviour {

    public UnityEvent event_;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        event_.Invoke();
    }

    public void wall()
    {
        Destroy(this.gameObject);
    }
}
