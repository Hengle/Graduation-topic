using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text_test : MonoBehaviour {

    public int num;

    public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        text.text = num.ToString();
	}

    public void num_add()
    {
        num++;
    }
}
