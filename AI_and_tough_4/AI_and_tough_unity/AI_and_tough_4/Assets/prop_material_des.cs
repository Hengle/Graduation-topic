using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prop_material_des : MonoBehaviour {

    [Header("切換材質球陣列要對準GameObject")]
    public Material[] change_Material;
    [Header("GameObject陣列")]
    public GameObject[] change_GameObject;
    [Header("要刪除的父物件")]
    public GameObject destroy_GameObject;

    public bool change_bool;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void prop_ok()
    {
        if(change_bool == true)
        {
            for (int i = 0; i < change_GameObject.Length; i++)
            {
                change_GameObject[i].GetComponent<Renderer>().material = change_Material[i];
            }

        }
       
        Destroy(this);
    }

    public void prop_no()
    {
        Destroy(destroy_GameObject);
    }

}
