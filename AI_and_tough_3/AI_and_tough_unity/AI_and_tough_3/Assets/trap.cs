using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour {

    public LayerMask layer;

    public float range;

    public float time;

    public Collider[] enemy;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        testdraw();
        if (time > 0)
        {
            trap_on();
            time -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    void trap_on()
    {
        enemy = Physics.OverlapSphere(this.transform.position, range, layer);
        if (enemy == null)
        {
            return;
        }
        foreach (Collider serch_colloder in enemy)
        {
            serch_colloder.transform.GetComponentInChildren<enemy_wait_event>().time = 9999;
            if (serch_colloder.transform.GetComponentInChildren<AI_tree_change_manger>().get_animator_name("exit") == false)
            {
                serch_colloder.transform.GetComponentInChildren<AI_tree_change_manger>().change_animator_name("exit", true);
                serch_colloder.transform.GetComponentInChildren<enemy_move_event>().target = serch_colloder.gameObject.transform.position;
                ui_manger.Instence.qte = true;
                //serch_colloder.transform.GetComponentInChildren<enemy_wait_event>().time = 9999;
                //Destroy(this);
            }
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
