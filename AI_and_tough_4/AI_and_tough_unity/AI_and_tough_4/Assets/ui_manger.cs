using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_manger : MonoBehaviour {

    public bool qte;

    public CanvasGroup qte_canves;

    public GameObject qte_game;

    public CanvasGroup ui_canves;

    private static ui_manger _instence;

    public static ui_manger Instence
    {
        get
        {
            return _instence;
        }

    }

    private void Awake()
    {
        _instence = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(qte ==true)
        {
            qte_game.SetActive(true);
            qte_canves.alpha += Time.deltaTime;
            ui_canves.alpha -= Time.deltaTime;
        }
	}
}
