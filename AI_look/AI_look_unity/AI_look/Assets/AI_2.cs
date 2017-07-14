using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_2 : MonoBehaviour {

    public GameObject target;
    public Vector3 temVec;

    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        temVec = target.transform.position;
        isInMyVision(target.GetComponent<Collider>());

    }


    public float maxVisionDistance;//视野长度
    public float maxVisionAngle;//视野角度
    bool isInMyVision(Collider c)
    {
        GameObject target = c.gameObject;
        //计算与目标距离
        float distance = Vector3.Distance(transform.position, target.transform.position);

        Vector3 mVec = transform.rotation * Vector3.forward;//当前朝向
        Vector3 tVec = target.transform.position - transform.position;//与目标连线的向量

        //计算两个向量间的夹角
        float angle = Mathf.Acos(Vector3.Dot(mVec.normalized, tVec.normalized)) * Mathf.Rad2Deg;
        if (distance < maxVisionDistance)
        {
            if (angle <= maxVisionAngle)
            {
                if (canSee(c))
                {
                    print("看到");
                    return true;
                }
            }
        }
        return false;
    }



    bool canSee(Collider c)
    {
        Ray DetectRay = new Ray(transform.position, temVec.normalized * maxVisionDistance);
        Debug.DrawRay(transform.position, temVec.normalized * maxVisionDistance);
        RaycastHit hitInfo;
        if (Physics.Raycast(DetectRay, out hitInfo, maxVisionDistance))
        {
            if (hitInfo.collider == c)
            {
                return true;
            }
        }
        return false;
    }


    void FindTarget()
    {
        Collider[] AllObejects = Physics.OverlapSphere(transform.position, maxVisionDistance);
        foreach (Collider c in AllObejects)
        {
            //仅对Player进行检测
            if (c.gameObject.tag == "Player")
            {
                if (isInMyVision(c))
                {
                    print("I see a target");
                    //在这里执行你想要进行的操作，比如设定寻路目标之类的
                }
            }
        }
    }

}
