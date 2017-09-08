using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prop_delay : MonoBehaviour {

    /// <summary>
    /// 時間倒數，倒數完道具啟用
    /// </summary>

    public prop_id prop_id;

    public Material prop_meterial;

    public float time;

    private void Awake()
    {
        prop_id = GetComponent<prop_id>();
        time = prop_id.prop_time;
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;

        if(time <= 0)
        {
            this.gameObject.GetComponent<Renderer>().material = prop_meterial;
            Destroy(this);
        }

	}
}
