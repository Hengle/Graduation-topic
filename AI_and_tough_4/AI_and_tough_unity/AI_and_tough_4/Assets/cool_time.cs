using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cool_time : MonoBehaviour
{

    public Toggle toggle_ui;

    public float time;

    public float time_cool;

    public bool cool_on;

    //public float cool_image_float;

    public Image cool_image;

    // Use this for initialization
    void Start()
    {
        time = time_cool;
    }

    // Update is called once per frame
    void Update()
    {
        if (cool_on == true)
        {
            Invasionlight_cool();
        }
    }

    void Invasionlight_cool()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
            cool_image.fillAmount = ((time_cool - time) / time_cool);
            toggle_ui.interactable = false;
        }
        else
        {
            time = time_cool;
            cool_image.fillAmount = 1;
            toggle_ui.interactable = true;
            cool_on = false;
        }
    }

    public void cool()
    {
        time = time_cool;
        cool_image.fillAmount = 0;
        toggle_ui.interactable = false;
        cool_on = true;
    }

}
