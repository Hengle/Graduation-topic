using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_Z : MonoBehaviour {

    /*
 //   public GameObject aaa;

    //   public Vector3 acemra;

    //   public Ray rayss;

    //   public float x;
    //   public float y;
    //   public Vector3 targetposition;

    //   // Use this for initialization
    //   void Start () {

    //}

    //// Update is called once per frame
    //void Update () {
    //       //acemra = Camera.main.ScreenToWorldPoint(new Vector3( Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z));
    //       ////print(Input.mousePosition);
    //       //print(acemra);

    //       if (Input.GetMouseButtonDown(0))
    //       {
    //           x = Input.mousePosition.x;
    //           y = Input.mousePosition.y;


    //       }

    //       targetposition = Camera.main.ScreenToWorldPoint(new Vector3(x, 1.1f, y));
    //       aaa.transform.position = Vector3.MoveTowards(transform.position, targetposition, Time.deltaTime * 2);

    //   }
    */

    //你現在的問題是要把螢幕2D的滑鼠座標(x , y , 0 )
    //轉換成滑鼠在那一點時的空間座標

    //先把你的人物的Transform放入 character
    //var character : Transform;   
    //創建一個相機
    //var mainCamera : Camera;    
    public Camera mainCamera;

    public Transform character;

    //然後做一個平面
    //var playerMovementPlane : Plane;    

    public Plane playerMovementPlane;

    public Vector3 cursorScreenPosition;

    public Vector3 cursorWorldPosition;

    public GameObject cube;

    private void Awake()
    {
        //        然後把mainCamera設為主相機
        //mainCamera = Camera.main;

        //playerMovementPlane = new Plane(character.up, character.position);
    }

    public float aaa;

    private void Update()
    {
        //        宣告螢幕2D的滑鼠質點
        //        var cursorScreenPosition: Vector3 = Input.mousePosition;
        //        宣告空間中的滑鼠質點 這裡要進行一些轉換就可以得到了  mainCamera是你的主相機
        //       var cursorWorldPosition: Vector3 = ScreenPointToWorldPointOnPlane(cursorScreenPosition, playerMovementPlane, mainCamera);

        playerMovementPlane = new Plane(character.up, character.position);
        //playerMovementPlane = new Plane(character.up, aaa);
        //playerMovementPlane = new Plane(new Vector3(0,0,0), new Vector3(0,0,1), new Vector3(1,0,1));

        cursorScreenPosition = Input.mousePosition;//滑鼠

        //cursorScreenPosition = Input.touches[0].position;//手指

        cursorWorldPosition = ScreenPointToWorldPointOnPlane(cursorScreenPosition, playerMovementPlane, mainCamera);
        print(cursorWorldPosition);
        cube.transform.position = cursorWorldPosition;
    }

    //function Awake()
    //    {
    //        然後把mainCamera設為主相機
    //        mainCamera = Camera.main;

    //        然後把NEW出這個平面並且把這個平面放到角色上
    //        playerMovementPlane = new Plane(character.up, character.position);
    //    }
    //    function Update()
    //    {
    //        宣告螢幕2D的滑鼠質點
    //        var cursorScreenPosition: Vector3 = Input.mousePosition;
    //        宣告空間中的滑鼠質點 這裡要進行一些轉換就可以得到了  mainCamera是你的主相機
    //       var cursorWorldPosition: Vector3 = ScreenPointToWorldPointOnPlane(cursorScreenPosition, playerMovementPlane, mainCamera);
    //    }

    public static Vector3 ScreenPointToWorldPointOnPlane(Vector3 screenPoint, Plane plane, Camera camera)
    {
        //將滑鼠的螢幕位置轉換成空間中的射線 ray=射線   
        //    var ray : Ray = camera.ScreenPointToRay(screenPoint);    
        Ray ray = camera.ScreenPointToRay(screenPoint);
        //    //找出射線與平面相交   
        //    return PlaneRayIntersection(plane, ray);
        Debug.DrawRay(ray.origin, ray.direction);

        return PlaneRayIntersection(plane, ray);
    }

    //    public static function ScreenPointToWorldPointOnPlane(screenPoint : Vector3, plane : Plane, camera : Camera) : Vector3 {    
    //    //將滑鼠的螢幕位置轉換成空間中的射線 ray=射線   
    //    var ray : Ray = camera.ScreenPointToRay(screenPoint);    
    //    //找出射線與平面相交   
    //    return PlaneRayIntersection(plane, ray);
    //}
    public static Vector3 PlaneRayIntersection(Plane plane, Ray ray)
    {
        //    var dist : float;    
        //    //光线投射 一条射线和平面相交。   
        //    plane.Raycast(ray, dist);    
        //    //获取点 返回沿着射线在distance距离单位的点。   
        //    return ray.GetPoint(dist);    
        float dist;
        plane.Raycast(ray,out dist);
        print(dist);
        return ray.GetPoint(dist);
    }

    //public static function PlaneRayIntersection(plane : Plane, ray : Ray) : Vector3 {    
    //    var dist : float;    
    //    //光线投射 一条射线和平面相交。   
    //    plane.Raycast(ray, dist);    
    //    //获取点 返回沿着射线在distance距离单位的点。   
    //    return ray.GetPoint(dist);    
    //}    


}
