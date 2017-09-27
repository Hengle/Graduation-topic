using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggle_prop : MonoBehaviour {

    [Header("表示UI中物件的控制腳本")]

    public hand_all hand_all;

    public camera_z_ray camera_z_ray;

    public prop_vec3_manger prop_vec3_manger;

    //該UI上所表示的物件
    [Header("該UI上所表示的物件")]
    public GameObject prop_gameobject;

    //public bool is_chack = false;

    private void Awake()
    {
        hand_all = (hand_all)FindObjectOfType(typeof(hand_all));
        camera_z_ray = (camera_z_ray)FindObjectOfType(typeof(camera_z_ray));
        prop_vec3_manger = (prop_vec3_manger)FindObjectOfType(typeof(prop_vec3_manger));
    }

    // Use this for initialization
    void Start()
    {
        if (prop_gameobject == null)
        {
            this.GetComponent<Toggle>().interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void chack_on()
    {
        //if (is_chack == false)
        //{
        //    prop_on();
        //}
        //else
        //{
        //    prop_off();
        //}

        //當按下時輸出數據到放置道具腳本，並改變按鈕
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
        hand_all.enabled = false;
        camera_z_ray.enabled = true;
        prop_vec3_manger.enabled = true;

        prop_vec3_manger.prop_gameobject_send(prop_gameobject , this.gameObject);

        //this.GetComponent<Image>().color = new Color32(125, 125, 125, 255);
        //is_chack = true;

        this.transform.GetChild(0).GetComponent<Image>().color = new Color32(125, 125, 125, 255);

    }

    void prop_off()
    {
        hand_all.enabled = true;
        camera_z_ray.enabled = false;
        prop_vec3_manger.enabled = false;

        //this.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        //is_chack = false;

        prop_vec3_manger.prop_gameobject = null;

        //prop_vec3_manger.prop_mode = "";

        //prop_vec3_manger.prop_mode_time =0;

        this.transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 255);

    }
}
