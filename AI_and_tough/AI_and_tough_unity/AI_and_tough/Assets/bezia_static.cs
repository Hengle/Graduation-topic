using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bezia_static : MonoBehaviour
{

    [Header("起始点")]
    public GameObject startPoint;
    [Header("控制点")]
    public GameObject controlPoint;
    [Header("目标点")]
    public GameObject endPoint;
    [Header("采样点的数量")]
    public int segmentNum;
    [Header("位置")]
    public Vector3[] path;

    // Use this for initialization
    void Start()
    {
        path = BezierUtils.GetBeizerList(startPoint.transform.position,controlPoint.transform.position, endPoint.transform.position, segmentNum);
    }

}
