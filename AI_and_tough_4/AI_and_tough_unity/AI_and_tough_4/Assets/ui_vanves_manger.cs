using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_vanves_manger : MonoBehaviour {

    public GameObject game;

    public GameObject ui_GameObject;

    public GameObject qte_GameObject;

    public Canvas ui_canves;

    public Canvas qte_canves;

    public float time_scaltime;

    public float time;

    public bool qte_to_ui;

    public bool ui_to_qte;

    public float speed;

    // Use this for initialization
    void Start () {
        time_scaltime = Time.realtimeSinceStartup - time;
        time = Time.realtimeSinceStartup;
    }
	
	// Update is called once per frame
	void Update () {

        time_scaltime = Time.realtimeSinceStartup - time;
        time = Time.realtimeSinceStartup;


        if (ui_to_qte == true)
        {
            cances_alpha_ui_to_qte();
        }

        if(qte_to_ui == true)
        {
            cances_alpha_qte_to_ui();
        }
	}

    public void qte_to_ui_on()
    {
        Time.timeScale = 0;
        qte_to_ui = true;
        //Time.timeScale = 1;
    }

    public void ui_to_qte_on()
    {
        Time.timeScale = 0;
        ui_to_qte = true;
    }

    void cances_alpha_ui_to_qte()
    {
        if(ui_canves.GetComponent<CanvasGroup>().alpha > 0)
        {
            ui_canves.GetComponent<CanvasGroup>().alpha -= speed * time_scaltime;
        }
        else
        {
            if(qte_canves.GetComponent<CanvasGroup>().alpha < 1)
            {
                qte_GameObject.SetActive(true);
                ui_GameObject.SetActive(false);
                qte_canves.GetComponent<CanvasGroup>().alpha += speed * time_scaltime;
            }
            else
            {
                qte_GameObject.SetActive(true);
                ui_GameObject.SetActive(false);
                game.SetActive(false);
                ui_to_qte = false;
                qte_to_ui = false;
                Time.timeScale = 1;
            }
        }
    }

    void cances_alpha_qte_to_ui()
    {
        if (qte_canves.GetComponent<CanvasGroup>().alpha > 0)
        {
            qte_canves.GetComponent<CanvasGroup>().alpha -= speed * time_scaltime;
        }
        else
        {
            if (ui_canves.GetComponent<CanvasGroup>().alpha < 1)
            {
                qte_GameObject.SetActive(false);
                ui_GameObject.SetActive(true);
                ui_canves.GetComponent<CanvasGroup>().alpha += speed * time_scaltime;
            }
            else
            {
                qte_GameObject.SetActive(false);
                ui_GameObject.SetActive(true);
                game.SetActive(true);
                ui_to_qte = false;
                qte_to_ui = false;
                Time.timeScale = 1;
            }
        }
    }
}
