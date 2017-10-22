using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nav_map_manger : MonoBehaviour {

    //地圖導航
    [Header("-----------------地圖導航------------------")]

    [Header("可以命中的LayerMask")]
    public LayerMask ray_layer;

    [Header("ray射出點")]
    public GameObject[] point;

    [Header("範圍1")]
    public Vector3 range_1;

    [Header("範圍2")]
    public Vector3 range_2;

    [Header("測試按鈕")]
    public bool test = false;

    public GameObject test_game;

    public Vector3 test_point;

    private static nav_map_manger _instance;

    public static nav_map_manger instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if (test == true)
        {
            map_point();
            test = false;
        }
        Debug.DrawLine(test_game.transform.position, test_point, Color.blue);
    }

    public Vector3 map_point()
    {
        Vector3 plane_range = new Vector3(Random.Range(range_1.x,range_2.x), 0, Random.Range(range_1.z,range_2.z));
        int num = Random.Range(0, point.Length);
        GameObject ray_gameobject = point[num];
        Vector3 target = new Vector3();

        Ray ray = new Ray(ray_gameobject.gameObject.transform.position, plane_range - ray_gameobject.gameObject.transform.position);

        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        Debug.DrawLine(ray_gameobject.gameObject.transform.position, plane_range, Color.cyan);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, ray_layer.value))
        {
            target =  hit.point;
        }

        test_game = ray_gameobject;
        test_point = target;

        return target;
    }



}
