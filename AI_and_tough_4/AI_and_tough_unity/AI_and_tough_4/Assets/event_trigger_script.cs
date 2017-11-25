using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event_trigger_script : MonoBehaviour {

    public LayerMask layer;

    public float range;

    public Collider[] enemy;

    public string ID;

    public bool first;

    

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        testdraw();
        music_boob_on();
        //Destroy(this.gameObject);
    }

    void music_boob_on()
    {
        enemy = Physics.OverlapSphere(this.transform.position, range, layer);
        if (enemy == null)
        {
            return;
        }

        foreach (Collider serch_colloder in enemy)
        {
            //serch_colloder.transform.GetComponentInChildren<enemy_wait_event>().time = 0;
            //serch_colloder.transform.GetComponentInChildren<enemy_move_event>().target = this.transform.position;
            //serch_colloder.transform.GetComponentInChildren<enemy_move_event>()

            serch_colloder.transform.GetComponentInChildren<event_all>().event_ID(ID,this.gameObject);
        }

        if(first == true)
        {
            Destroy(this.gameObject);
        }

    }

    void testdraw()
    {
        Debug.DrawRay(this.transform.position, Vector3.back * range, Color.black);
        Debug.DrawRay(this.transform.position, Vector3.down * range, Color.black);
        Debug.DrawRay(this.transform.position, Vector3.forward * range, Color.black);
        Debug.DrawRay(this.transform.position, Vector3.left * range, Color.black);
        Debug.DrawRay(this.transform.position, Vector3.right * range, Color.black);
        Debug.DrawRay(this.transform.position, Vector3.up * range, Color.black);
    }
}
