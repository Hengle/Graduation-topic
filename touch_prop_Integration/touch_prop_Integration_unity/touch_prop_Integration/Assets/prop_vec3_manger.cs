using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prop_vec3_manger : MonoBehaviour
{

    //camera_z_ray腳本
    [Header("camera_z_ray腳本")]
    public camera_z_ray camera_z;

    //camera_z_ray腳本點擊位置
    [Header("camera_z_ray腳本點擊位置")]
    public Vector3 camera_z_vec3;

    //傳輸過來的道具
    [Header("傳輸過來的道具")]
    public GameObject prop_gameobject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //camera_z_vec3 = camera_z.camera_ray_point_vec3;

    }

    public void prop_gameobject_send(GameObject gameobject_name)
    {
        prop_gameobject = gameobject_name;
    }

}
