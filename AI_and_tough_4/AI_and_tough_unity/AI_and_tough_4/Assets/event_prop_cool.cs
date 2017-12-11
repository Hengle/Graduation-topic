using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event_prop_cool : MonoBehaviour
{

    public cool_time _cool_Time;


    private void Awake()
    {
        _cool_Time = (cool_time)FindObjectOfType(typeof(cool_time));
    }

    // Use this for initialization
    void Start()
    {
        _cool_Time.cool();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
