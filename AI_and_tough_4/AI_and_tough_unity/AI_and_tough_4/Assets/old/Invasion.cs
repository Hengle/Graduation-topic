using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invasion : MonoBehaviour {

    public LayerMask layer;

    public Collider[] target;

    public float range;

    public string ID = "Invasion";

    //public enemy_event_manger[] _enemy_event_manger;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        target = Physics.OverlapSphere(this.gameObject.transform.position, range, layer);

        if(target.Length == 0)
        {
            return;
        }
        else
        {
            foreach (Collider serch_colloder in target)
            {
                //print(serch_colloder.gameObject.name);
                serch_colloder.GetComponent<event_all>().event_ID(ID,null);
            }
        }

      

        Debug.DrawLine(this.transform.position, this.transform.position + new Vector3(range, 0, 0),Color.blue);
        Debug.DrawLine(this.transform.position, this.transform.position + new Vector3(-range, 0, 0), Color.blue);
        Debug.DrawLine(this.transform.position, this.transform.position + new Vector3(0, range, 0), Color.blue);
        Debug.DrawLine(this.transform.position, this.transform.position + new Vector3(0, -range, 0), Color.blue);
        Debug.DrawLine(this.transform.position, this.transform.position + new Vector3(0, 0, range), Color.blue);
        Debug.DrawLine(this.transform.position, this.transform.position + new Vector3(0, 0, -range), Color.blue);
    }
}
