using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_2 : MonoBehaviour {

    public Collider[] AllObejects;

    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {

        FindTarget();
    }


    public float maxVisionDistance;//视野长度
    public float maxVisionAngle;//视野角度

    /// <summary>
    /// 一、用扇形区域模拟怪物的视野范围
    /// 首先，设定最大可视距离maxVisionDistance和最大视野角度maxVisionAngle
    // 当玩家与怪物的 距离<maxVisionDistance, 角度<maxVisionAngle,那么玩家进入怪物的视野范围
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    bool isInMyVision(Collider c)
    {
        GameObject target = c.gameObject;
        //计算与目标距离
        float distance = Vector3.Distance(transform.position, target.transform.position);

        Vector3 mVec = transform.rotation * Vector3.forward;//当前朝向
        //意旨在當前旋轉角度下，前方1單位的座標

        //Vector3 mVec = transform.rotation * Vector3.right;//当前朝向
        Vector3 tVec = target.transform.position - transform.position;//与目标连线的向量

        //Eular 角的旋轉方式
        //如果單純只是根據一個X,Y,Z軸做旋轉則 Eular 角的旋轉方式還是比較快而簡便的
        //根據 Z 軸做旋轉
        //vector = Quaternion.Euler(0, 0, 角度)  * 欲選轉向量;


        //计算两个向量间的夹角
        float angle = Mathf.Acos(Vector3.Dot(mVec.normalized, tVec.normalized)) * Mathf.Rad2Deg;
        
        //Dot內積，
        //a·b=|a|·|b|cos<a,b> 【注：粗体小写字母表示向量，<a,b>表示向量a,b的夹角，取值范围为[0，π(180度)]】
        //1.根据点乘计算两个向量的夹角。<a,b>(夾角)= arccos(a·b / (|a|·|b|)) arccos(反三角函數cos)
        //2.根据点乘的正负值，得到夹角大小范围，>0，则夹角（0,90）<0,则夹角（90,180），可以利用这点判断一个多边形是面向摄像机还是背向摄像机。

        //角度 = 反cos(內積(當前座標點,目標物座標點(normalized規範化成1，來省去除法運算))) * 轉換成角度

        //print(Vector3.Dot(mVec.normalized, tVec.normalized));
        //print(Mathf.Acos(Vector3.Dot(mVec.normalized, tVec.normalized)));
        //print(Mathf.Acos(Vector3.Dot(mVec.normalized, tVec.normalized)) * Mathf.Rad2Deg);
        //print("Angle  " + angle);

        if (distance < maxVisionDistance)
        {
            if (angle <= maxVisionAngle)
            {
                if (canSee(c))
                {
                    print("看到" + distance);
                    return true;
                }
            }
        }
        return false;
    }


    /// <summary>
    /// 二、排除遮挡
    /// 如果我们的玩家想要不惊动怪物，暗中观察，或许会躲在一块石头后面。
    /// 直接用上述判断距离和角度的方法显然是不行的，我们需要追加一个判断是否有障碍物遮挡视野，这里我想的办法是用射线来解决。
    /// 从当前点向目标位置发射一条射线Ray，如果碰撞到的第一个物体是目标物体，就判定没有遮挡，这样的话，最好将这个脚本绑定到怪物的“眼睛”这个地方，让它有一定的高度。
    /// 我这里只是大致判断了一下，当然可以有更精确的判断方式，请各位发挥想象力
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    bool canSee(Collider c)
    {
        //畫一射線過去，是否被擋住
        //Ray DetectRay = new Ray(transform.position, c.gameObject.transform.position.normalized * maxVisionDistance);
        //畫一射線過去，是否被擋住
        //(c.gameObject.transform.position - transform.position).normalized 指與目標物之間向量，在Ray裡為方向
        Vector3 tVec = (c.gameObject.transform.position - transform.position).normalized;
        Ray DetectRay = new Ray(transform.position, tVec);

        //射線上色
        Debug.DrawRay(transform.position, c.gameObject.transform.position.normalized * maxVisionDistance);
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

    /// <summary>
    /// 三、扩展思考
    /// 在多人游戏中，可能有多个玩家，这个时候，只设定一个 target是不够的
    /// 我们可以先将视野中的可能目标先找出来，再进行排除和选择,用一个简单的球形扫描Physics.OverlapSphere就可以找出所有目标了，可以设定个tag或者layer来进行选择
    /// </summary>
    void FindTarget()
    {
        //畫個圓形碰撞，範圍內物件編入陣列
        AllObejects = Physics.OverlapSphere(transform.position, maxVisionDistance);
        foreach (Collider c in AllObejects)
        {
            //仅对Player进行检测
            if (c.gameObject.tag == "Player")
            {
                if (isInMyVision(c))
                {
                    //print("I see a target");
                    //在这里执行你想要进行的操作，比如设定寻路目标之类的
                }
            }
        }
    }

}
