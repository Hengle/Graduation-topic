using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_ : MonoBehaviour {

    //视野区域
    public float HorSight = 120f;
    public float VerSight = 60f;
    //视野距离
    public float sightDis = 100f;
    //目标点
    public Transform target;

    //视野方向
    public Vector3 leftDir, rightDir, upDir, downDir;

    //射线
    public Ray ray;


    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        Vector3 tempForward = transform.forward;


        //此处是计算相对于this的左右区域，必须用transform.up 而不能用vector3.up

        //自身为中心，向左旋转视野范围一半
        Quaternion left = Quaternion.AngleAxis(-HorSight / 2, transform.up);
        //自身为中心，向右旋转视野范围一半
        Quaternion right = Quaternion.AngleAxis(HorSight / 2, transform.up);
        //自身为中心，向上旋转视野范围一半
        Quaternion up = Quaternion.AngleAxis(-VerSight / 2, transform.right);
        //自身为中心，向下旋转视野范围一半
        Quaternion down = Quaternion.AngleAxis(VerSight / 2, transform.right);

        //左边视野方向
        leftDir = left * tempForward;
        //右边视野方向
        rightDir = right * tempForward;
        //上视野方向
        upDir = up * tempForward;
        //下视野方向
        downDir = down * tempForward;

        #region 测试
        //左，蓝色
        Debug.DrawLine(transform.position, transform.position + leftDir * sightDis, Color.blue);
        //右，红色
        Debug.DrawLine(transform.position, transform.position + rightDir * sightDis, Color.red);
        //上，白色
        Debug.DrawLine(transform.position, transform.position + upDir * sightDis, Color.white);
        //下，绿色
        Debug.DrawLine(transform.position, transform.position + downDir * sightDis, Color.green);


        #endregion

        //进入视野距离的时候调用
        if (Vector3.Distance(transform.position, target.position) < sightDis)
        {

            ComputerSight();
        }
    }





    void ComputerSight()
    {
        Vector3 dir = target.transform.position - transform.position; //求出this 到目标点的方向

        //根据目标点的方向，求出目标点在水平、竖直方向上的投影
        Vector3 targetHorPos = new Vector3(dir.x, leftDir.y, dir.z);//求水平方向投影
        Vector3 targetVerPos = new Vector3(upDir.x, dir.y, dir.z);//求竖直方向投影

        //叉乘
        Vector3 leftCross = Vector3.Cross(targetHorPos, leftDir);
        Vector3 rightCross = Vector3.Cross(targetHorPos, rightDir);

        Vector3 upCross = Vector3.Cross(targetVerPos, upDir);
        Vector3 downCross = Vector3.Cross(targetVerPos, downDir);


        if (dir.z > 0)
        {
            //判断，  因为使用的是目标点在水平、竖直方向上的投影乘以左右两个方向，如果在左右两个方向包含的区域之内，那么所得向量方向是必然相反的，点乘为负数
            if (Vector3.Dot(leftCross, rightCross) < 0)
            {
                Debug.Log("在水平视角内");
            }
            if (Vector3.Dot(upCross, downCross) < 0)
            {
                Debug.Log("在垂直视角范围内");
            }
        }
    }
}
