using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_toggle_id : MonoBehaviour {

    [Header("表示UI中物件的控制腳本")]

    public hand_tough_manger hand_tough_manger;

    public prop_manger prop_manger;

    //該UI上所表示的物件
    [Header("該UI上所表示的物件")]
    public GameObject prop_gameobject;

    private void Awake()
    {
        hand_tough_manger = (hand_tough_manger)FindObjectOfType(typeof(hand_tough_manger));
        prop_manger = (prop_manger)FindObjectOfType(typeof(prop_manger));

        if (prop_gameobject == null)
        {
            this.GetComponent<Toggle>().interactable = false;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    public void chack_on()
    {
        if (this.GetComponent<Toggle>().isOn == true)
        {
            prop_on();
        }
        else
        {
            prop_off();
        }
    }

        void prop_on()
    {
        //hand_all.enabled = false;
        //camera_z_ray.enabled = true;
        //prop_vec3_manger.enabled = true;

        //prop_vec3_manger.prop_gameobject_send(prop_gameobject, this.gameObject);

        //this.GetComponent<Image>().color = new Color32(125, 125, 125, 255);
        //is_chack = true;

        hand_tough_manger.script_close = true;

        prop_manger.script_close = false;

        prop_manger.prop_gameobject_send(prop_gameobject, this.gameObject);

        this.transform.GetChild(0).GetComponent<Image>().color = new Color32(125, 125, 125, 255);

    }

    void prop_off()
    {
        //hand_all.enabled = true;
        //camera_z_ray.enabled = false;
        //prop_vec3_manger.enabled = false;

        ////this.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        ////is_chack = false;

        //prop_vec3_manger.prop_gameobject = null;

        //prop_vec3_manger.prop_mode = "";

        //prop_vec3_manger.prop_mode_time =0;

        hand_tough_manger.script_close = false;

        prop_manger.script_close = true;

        this.transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 255);

    }
}
