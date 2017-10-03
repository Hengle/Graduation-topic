using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_z_ray : MonoBehaviour {

    [Header("當要放置物體時才啟動")]

    //攝影機Ray-----------------------------------
    [Header("-----------------攝影機Ray------------------")]

    //攝影機組件
    [Header("攝影機組件")]
    public Camera camera_ray;

    //攝影機Ray位置
    [Header("攝影機Ray位置")]
    public Vector3 camera_ray_point_vec3;

    public Vector3 Camera_ray_point_vec3
    {
        get
        {
            return camera_ray_point_vec3;
        }
    }

    private void Awake()
    {
        camera_ray = (Camera)FindObjectOfType(typeof(Camera));
    }

    // Use this for initialization
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.touchCount == 0)
        {
            return;
        }
        else
        {
            if(Input.touches[0].position.y < 300)
            {
                return;
            }
            camera_z_ray_function();
        }
       
    }

    /// <summary>
    /// 攝影機點擊位置(對方需要 Colider)
    /// </summary>
    void camera_z_ray_function()
    {
        Ray ray = camera_ray.ScreenPointToRay(Input.touches[0].position);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction);
        if (Physics.Raycast(ray, out hit))
        {
            //print(hit.collider.gameObject.name + hit.point);
            print(hit.point);
            camera_ray_point_vec3 = hit.point;
            //cube.transform.position = hit.point;
        }
    }

}
