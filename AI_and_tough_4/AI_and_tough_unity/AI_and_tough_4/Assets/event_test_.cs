using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event_test_ : MonoBehaviour {

    public LayerMask layer;

    public float range;

    public Collider[] enemy;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        enemy = Physics.OverlapSphere(this.transform.position, range, layer);
    }
}
