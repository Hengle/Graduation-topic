using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_data : MonoBehaviour {

    public float maintain = 100;
    public float hunger = 100;
    public float mood = 100;

    public float maintain_last;
    public float hunger_last;

    [Header ("減的秒數(請填秒數)")]
    public float maintain_time;
    [Header("減的秒數(請填秒數)")]
    public float hunger_time;

    private void Awake()
    {
        maintain_last = maintain;
        hunger_last = hunger;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        maintain -= (maintain_last / maintain_time) * Time.deltaTime;
        hunger -= (hunger_last / hunger_time) * Time.deltaTime;
    }
}
