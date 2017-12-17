using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event_trigger_script : MonoBehaviour {

    [Header("執行")]
    public bool start;
    [Header("只執行一次")]
    public bool first;
    [Header("執行幾秒 first 在 false 下才行")]
    public float time;
    [Header("要偵測的物件Tag名字")]
    public string tag_name;

    public LayerMask layer;

    public float range;

    public Collider[] enemy;

    public string ID;


    public event_all _event_all;

    public Object Destroy_Object;

    public bool Destroy_Object_this_gameobject;

    public bool Destroy_Object_this;

    private void Awake()
    {
        _event_all = (event_all)FindObjectOfType(typeof(event_all));

        if(Destroy_Object_this_gameobject == true)
        {
            Destroy_Object = this.gameObject;
        }

        if (Destroy_Object_this == true)
        {
            Destroy_Object = this;
        }

    }


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if(start == true)
        {
            testdraw();
            music_boob_on();
            //Destroy(this.gameObject);
        }
    }

    void music_boob_on()
    {
        enemy = Physics.OverlapSphere(this.transform.position, range, layer);
        //if (enemy == null)
        //{
        //    return;
        //}

        foreach (Collider serch_colloder in enemy)
        {
            //serch_colloder.transform.GetComponentInChildren<enemy_wait_event>().time = 0;
            //serch_colloder.transform.GetComponentInChildren<enemy_move_event>().target = this.transform.position;
            //serch_colloder.transform.GetComponentInChildren<enemy_move_event>()

            //serch_colloder.transform.GetComponentInChildren<event_all>().event_ID(ID,this.gameObject);

            if (serch_colloder.gameObject.tag == tag_name)
            {
                _event_all.event_ID(ID, this.gameObject);
            }

        }

        if(first == true)
        {
            Destroy(Destroy_Object);
        }
        else
        {
            time -= Time.deltaTime;

            if(time <=0)
            {
                Destroy(Destroy_Object);
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
