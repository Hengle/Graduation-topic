using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class value_test : MonoBehaviour {

    public Text value_Text;

    public Text time_Text;

    public float value;

    public float time_scaltime;

    public float time;

    public float time_string;

    public ui_vanves_manger ui_Vanves_Manger;

    public Canvas qte;

    // Use this for initialization
    void Start () {
        time_scaltime = Time.realtimeSinceStartup - time;
        time = Time.realtimeSinceStartup;
    }
	
	// Update is called once per frame
	void Update () {

        if(qte.GetComponent<CanvasGroup>().alpha == 1)
        {
            time_scaltime = Time.realtimeSinceStartup - time;
            time = Time.realtimeSinceStartup;

            time_string += time_scaltime;

            time_Text.text = time_string.ToString();
            value_Text.text = value.ToString().PadLeft(8, '0');

            if (time_string > 60)
            {
                ui_Vanves_Manger.qte_to_ui_on();
                time_string = 0;
            }
        }
        else
        {
            time_string = 0;
        }

     

    }

    public void value_on(string name)
    {
        if (name == "bullet01")
        {
            value += 1;
        }
        else if(name == "bullet02")
        {
            value += 100;
        }
        else if (name == "bullet03")
        {
            value += 10000;
        }
        else if (name == "bullet04")
        {
            value += 1000000;
        }


    }
}
