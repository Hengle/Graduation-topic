using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eye_mesh_test : MonoBehaviour
{

    public LayerMask layer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Mathf.Log(layer, 2))
        {
            print(other.gameObject + "  " + Time.time);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == Mathf.Log(layer,2))
        {
            print(other.gameObject + "  " + Time.time);
        }
    }

}
