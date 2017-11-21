using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_Z_2 : MonoBehaviour {

    public GameObject cube;

    public Camera mainCamera;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //滑鼠
        //Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        //手指
        Ray ray = mainCamera.ScreenPointToRay(Input.touches[0].position);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction);
        if (Physics.Raycast(ray, out hit))
        {
            //print(hit.collider.gameObject.name + hit.point);
            print(hit.point);
            cube.transform.position = hit.point;
        }
            
        //if (Input.GetMouseButton(0) && Physics.Raycast(ray, out hit))
        //{
        //    Debug.DrawLine(Camera.main.transform.position, hit.transform.position, Color.red, 0.1f, true);
        //    Debug.Log(hit.transform.name);
        //}
    }
}
