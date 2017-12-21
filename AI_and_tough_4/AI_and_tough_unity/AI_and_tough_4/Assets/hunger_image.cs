using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hunger_image : MonoBehaviour {

    public Image target;

    public float max;

    public float now;

    public event_all _event_all;

    private void Awake()
    {
        _event_all = (event_all)FindObjectOfType(typeof(event_all));
        max = _event_all.hunger_value_last;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        now = _event_all.hunger_value;
        target.fillAmount = now / max;

    }
}
