using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prop_manger : MonoBehaviour
{

    [Header("道具與其他腳本控管")]
    [Header("---------------------------------")]

    //傳輸過來的道具
    [Header("傳輸過來的道具")]
    public GameObject prop_gameobject;

    //傳輸過來的UI
    [Header("傳輸過來的UI")]
    public GameObject ui_gameobject;

    [Header("道具使用中")]
    [Header("---------------------------------")]

    //道具是否使用
    [Header("道具是否使用")]
    public bool is_first_prop_ok = false;

    //攝影機Ray-----------------------------------
    [Header("-----------------攝影機Ray------------------")]

    //攝影機組件
    [Header("攝影機組件")]
    public Camera camera_ray;

    //攝影機Ray位置
    [Header("攝影機Ray位置")]
    public Vector3 camera_ray_point_vec3;

    public GameObject aaa;

    public GameObject bbb;

    public bool ccc;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ccc =dead_tough(aaa, bbb, Input.touches[0].position);
        print(Input.touches[0].position + " " + ccc);
    }

    bool dead_tough(GameObject point_1, GameObject point_2, Vector3 input_pos)
    {

        if (((point_1.transform.position.x > input_pos.x) && (input_pos.x > point_2.transform.position.x)) &&
            ((point_1.transform.position.y > input_pos.y) && (input_pos.y > point_2.transform.position.y)))
        {
            return true;
        }
        else if (((point_1.transform.position.x > input_pos.x) && (input_pos.x > point_2.transform.position.x)) &&
           ((point_1.transform.position.y < input_pos.y) && (input_pos.y < point_2.transform.position.y)))
        {
            return true;
        }
        else if (((point_1.transform.position.x < input_pos.x) && (input_pos.x < point_2.transform.position.x)) &&
               ((point_1.transform.position.y > input_pos.y) && (input_pos.y > point_2.transform.position.y)))
        {
            return true;
        }
        else if (((point_1.transform.position.x < input_pos.x) && (input_pos.x < point_2.transform.position.x)) &&
                ((point_1.transform.position.y < input_pos.y) && (input_pos.y < point_2.transform.position.y)))
        {
            return true;
        }

        return false;
    }

}
