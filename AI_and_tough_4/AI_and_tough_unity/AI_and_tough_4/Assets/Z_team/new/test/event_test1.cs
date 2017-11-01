using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event_test1 : MonoBehaviour {

    public int num;

    public event_array _event_array;

    // Use this for initialization
    void Start()
    {
        _event_array = this.GetComponent<event_array>();

    }

    // Update is called once per frame
    void Update () {
        //if (_event_array.i == num)
        //{
        //    event_on1();
        //}
    }

    public void event_on1()
    {
        if (_event_array.i == num)
        {
            print(this.name);
            _event_array.next();
        }
    }
}
