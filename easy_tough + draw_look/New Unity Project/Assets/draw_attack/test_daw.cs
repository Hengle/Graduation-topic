using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_daw : MonoBehaviour {

    public float aaa,bbb;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        DrawTool.DrawSector(transform, transform.localPosition, aaa, bbb);
        //DrawTool.DrawSectorSolid(transform, transform.localPosition, aaa, bbb);
    }
}
