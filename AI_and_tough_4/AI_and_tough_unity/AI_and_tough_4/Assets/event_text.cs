using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class event_text : MonoBehaviour {

    public Text text;

    public GameObject time_text;

    public GameObject time_text_gameobject;

    public GameObject canves;

    public float time;

    public float time_prop;

    public Vector2 offect;

    public bool on;

    public float on_time;

    private void Awake()
    {
        canves = GameObject.FindGameObjectWithTag("ui");
        time_text_gameobject = GameObject.Instantiate(time_text, canves.transform);
        text = time_text_gameobject.GetComponent<Text>();
        time = time_prop;
    }

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        if (on == true)
        {
            time_text_on();
        }
        else
        {
            on_time += Time.deltaTime;
            if(on_time > 0.1f)
            {
                time -= on_time;
                on = true;
            }
        }
    }

    void time_text_on()
    {
        if (time > 0.01f)
        {
            time_text_gameobject.transform.position = Input.touches[0].position + offect;
            time -= Time.deltaTime;
            //print(Mathf.FloorToInt(time) + " " + time);
            //text.text = Mathf.FloorToInt(time).ToString();
            text.text = Mathf.Floor(time).ToString();
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnDestroy()
    {
        Destroy(time_text_gameobject);
    }
}
