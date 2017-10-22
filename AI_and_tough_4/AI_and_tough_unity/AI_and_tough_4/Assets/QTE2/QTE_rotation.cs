using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE_rotation : MonoBehaviour
{

    public GameObject target_rotation;

    public float target_rotation_speed_max;

    public float target_rotation_speed_min;

    public float target_rotation_speed;



    // Use this for initialization
    void Start()
    {
        target_rotation_speed = Random.Range(target_rotation_speed_min, target_rotation_speed_max);
    }

    // Update is called once per frame
    void Update()
    {
        target_rotation.transform.rotation = Quaternion.Euler((target_rotation.transform.rotation.eulerAngles + new Vector3(0, 0, target_rotation_speed)));
    }

    public void stop()
    {
        target_rotation_speed = Random.Range(target_rotation_speed_min, target_rotation_speed_max);
    }
}
