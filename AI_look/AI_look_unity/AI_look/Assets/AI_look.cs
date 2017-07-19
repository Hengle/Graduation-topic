using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_look : MonoBehaviour
{
    //public enum see_direction { x_plus, x_minus, y_plus, y_minus, z_plus, z_minus }

    //public see_direction see_direct;

    public Collider[] serch_colloder_find;

    //public Vector3 see_direct_vec3;

    public float min_eye_distance = 1f;
    public float max_eye_distance;
    public float max_eye_angle;

    

    // Use this for initialization
    void Start()
    {
        //start_see_direct();

        if(min_eye_distance >max_eye_distance)
        {
            min_eye_distance = 1f;
            max_eye_distance = 2f;
        }

    }

    void Update()
    {
        //Eular 角的旋轉方式
        //如果單純只是根據一個X,Y,Z軸做旋轉則 Eular 角的旋轉方式還是比較快而簡便的

        //根據 Z 軸做旋轉
        //vector = Quaternion.Euler(0, 0, 角度)  * 欲選轉向量;
        //start_see_direct();
        test_draw();

    }

    //void start_see_direct()
    //{
    //    if (see_direct == see_direction.x_plus)
    //    {
    //        see_direct_vec3 = Vector3.right;
    //    }
    //    else if (see_direct == see_direction.x_minus)
    //    {
    //        see_direct_vec3 = Vector3.left;
    //    }
    //    else if (see_direct == see_direction.y_plus)
    //    {
    //        see_direct_vec3 = Vector3.up;
    //    }
    //    else if (see_direct == see_direction.y_minus)
    //    {
    //        see_direct_vec3 = Vector3.down;
    //    }
    //    else if (see_direct == see_direction.z_plus)
    //    {
    //        see_direct_vec3 = Vector3.forward;
    //    }
    //    else if (see_direct == see_direction.z_minus)
    //    {
    //        see_direct_vec3 = Vector3.back;
    //    }
    //}

    /// <summary>
    /// 搜尋物件
    /// </summary>
    void collider_serch()
    {
        //範圍內所有物件
        serch_colloder_find = Physics.OverlapSphere(this.transform.position, max_eye_distance);

        //測試範圍
        //Debug.DrawLine(this.transform.position, this.transf.orm.position + new Vector3(max_eye_distance, 0, 0), Color.green);
        //Debug.DrawLine(this.transform.position, this.transf.orm.position + new Vector3(-max_eye_distance, 0, 0), Color.green);
        //Debug.DrawLine(this.transform.position, this.transf.orm.position + new Vector3(0, max_eye_distance, 0), Color.green);
        //Debug.DrawLine(this.transform.position, this.trans.form.position + new Vector3(0, -max_eye_distance, 0), Color.green);
        //Debug.DrawLine(this.transform.position, this.tran.sform.position + new Vector3(0, 0, max_eye_distance), Color.green);
        //Debug.DrawLine(this.transform.position, this.transform.position + new Vector3(0, 0, -max_eye_distance), Color.green);

    }
    
    /// <summary>
    /// 計算是否看到
    /// </summary>
    /// <param name="target_collider"></param>
    /// <returns></returns>
    bool see_distance(Collider target_collider)
    {
        //目標.物
        GameObject target = target_collider.gameObject;
        //目標距離
        float distance = Vector3.Distance(this.transform.position, target.transform.position);

        //意旨在當前旋轉角度下，前方1單位的座標
        //Eular 角的旋轉方式
        //如果單純只是根據一個X,Y,Z軸做旋轉則 Eular 角的旋轉方式還是比較快而簡便的
        //根據 Z 軸做旋轉
        //vector = Quaternion.Euler(0, 0, 角度)  * 欲選轉向量;
        //Vector3 mVec = transform.rotation * (see_direct_vec3 * min_eye_distance);//当前朝向

        Vector3 mVec = transform.rotation * (Vector3.forward * min_eye_distance);//当前朝向

        Vector3 tVec = target.transform.position - transform.position;//与目标连线的向量

        //计算两个向量间的夹角
        float angle = Mathf.Acos(Vector3.Dot(mVec.normalized, tVec.normalized)) * Mathf.Rad2Deg;

        //Dot內積，
        //a·b=|a|·|b|cos<a,b> 【注：粗体小写字母表示向量，<a,b>表示向量a,b的夹角，取值范围为[0，π(180度)]】
        //1.根据点乘计算两个向量的夹角。<a,b>(夾角)= arccos(a·b / (|a|·|b|)) arccos(反三角函數cos)
        //2.根据点乘的正负值，得到夹角大小范围，>0.，则夹角（0,9.0）<0,则夹角（90,180），可以利用这点判断一个多边形是面向摄像机还是背向摄像机。

        //角度 = 反co.s(內積(當前座標點,目標物座標點(normalized規範化成1，來省去除法運算))) * 轉換成角度

        if ((distance < max_eye_distance) &&(distance > min_eye_distance))
        {
            if (angle <= max_eye_angle)
            {
                if (canSee(target_collider))
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
        //畫一射線過去，是否被擋住
        Ray DetectRay = new Ray(transform.position, c.gameObject.transform.position.normalized * max_eye_distance);
        //射線上色
        Debug.DrawRay(transform.position, c.gameObject.transform.position.normalized * max_eye_distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(DetectRay, out hitInfo, max_eye_distance))
        {
            if (hitInfo.collider == c)
            {
                return true;
            }
        }
        return false;
    }

    //public float x;
    //public float y;
    //public float z;

    void test_draw()
    {
        //看見方向
        //Debug.DrawLine(this.transform.position, transform.rotation * see_direct_vec3, Color.black);
        Debug.DrawLine(this.transform.position, transform.rotation * Vector3.forward, Color.black);

        //看見範圍
        //Vector3 see_right_max = this.transform.rotation * Quaternion.Euler(0f, max_eye_angle, 0f) * see_direct_vec3;
        //Vector3 see_right_min = this.transform.rotation * Quaternion.Euler(0f, max_eye_angle, 0f) * see_direct_vec3;
        //Vector3 see_left_max = this.transform.rotation * Quaternion.Euler(0f, -max_eye_angle, 0f) * see_direct_vec3;
        //Vector3 see_left_min = this.transform.rotation * Quaternion.Euler(0f, -max_eye_angle, 0f) * see_direct_vec3;

        Vector3 see_right_max = this.transform.rotation * Quaternion.Euler(0f, max_eye_angle, 0f) * Vector3.forward;
        Vector3 see_right_min = this.transform.rotation * Quaternion.Euler(0f, max_eye_angle, 0f) * Vector3.forward;
        Vector3 see_left_max = this.transform.rotation * Quaternion.Euler(0f, -max_eye_angle, 0f) * Vector3.forward;
        Vector3 see_left_min = this.transform.rotation * Quaternion.Euler(0f, -max_eye_angle, 0f) * Vector3.forward;


        Vector3 see_up_max = this.transform.rotation * Quaternion.Euler(max_eye_angle, 0, 0f) * Vector3.forward;
        Vector3 see_up_min = this.transform.rotation * Quaternion.Euler(max_eye_angle, 0, 0f) * Vector3.forward;
        Vector3 see_down_max = this.transform.rotation * Quaternion.Euler(-max_eye_angle, 0, 0f) * Vector3.forward;
        Vector3 see_down_min = this.transform.rotation * Quaternion.Euler(-max_eye_angle, 0, 0f) * Vector3.forward;

        Vector3 see_up_right_max = this.transform.rotation * Quaternion.Euler(max_eye_angle, max_eye_angle, 0f) * Vector3.forward;
        Vector3 see_up_right_min = this.transform.rotation * Quaternion.Euler(max_eye_angle, max_eye_angle, 0f) * Vector3.forward;
        Vector3 see_down_left_max = this.transform.rotation * Quaternion.Euler(-max_eye_angle, -max_eye_angle, 0f) * Vector3.forward;
        Vector3 see_down_left_min = this.transform.rotation * Quaternion.Euler(-max_eye_angle, -max_eye_angle, 0f) * Vector3.forward;

        Vector3 see_down_right_max = this.transform.rotation * Quaternion.Euler(max_eye_angle, -max_eye_angle, 0f) * Vector3.forward;
        Vector3 see_down_right_min = this.transform.rotation * Quaternion.Euler(max_eye_angle, -max_eye_angle, 0f) * Vector3.forward;
        Vector3 see_up_left_max = this.transform.rotation * Quaternion.Euler(-max_eye_angle, max_eye_angle, 0f) * Vector3.forward;
        Vector3 see_up_left_min = this.transform.rotation * Quaternion.Euler(-max_eye_angle, max_eye_angle, 0f) * Vector3.forward;

      

        //Vector3 see_right_up_max = this.transform.rotation * Quaternion.Euler(x, y, z) * see_direct_vec3;
        
        //Vector3 see_right_up_min = this.transform.rotation * Quaternion.Euler(max_eye_angle, max_eye_angle, 0f) * see_direct_vec3;
        //Vector3 see_left_up_max = this.transform.rotation * Quaternion.Euler(-max_eye_angle, max_eye_angle, 0f) * see_direct_vec3;
        //Vector3 see_left_up_min = this.transform.rotation * Quaternion.Euler(-max_eye_angle, max_eye_angle, 0f) * see_direct_vec3;
        //Vector3 see_right_down_max = this.transform.rotation * Quaternion.Euler(max_eye_angle, -max_eye_angle, 0f) * see_direct_vec3;
        //Vector3 see_right_down_min = this.transform.rotation * Quaternion.Euler(max_eye_angle, -max_eye_angle, 0f) * see_direct_vec3;
        //Vector3 see_left_down_max = this.transform.rotation * Quaternion.Euler(-max_eye_angle, -max_eye_angle, 0f) * see_direct_vec3;
        //Vector3 see_left_down_min = this.transform.rotation * Quaternion.Euler(-max_eye_angle, -max_eye_angle, 0f) * see_direct_vec3;

        //Vector3 see_right_up = this.transform.rotation * Quaternion.Euler(max_eye_angle, max_eye_angle, 0) * (Vector3.forward*min_eye_distance);
        //Vector3 see_right_down = this.transform.rotation * Quaternion.Euler(max_eye_angle, max_eye_angle, 0) *( Vector3.forward*max_eye_distance);
        //Vector3 see_left_up = this.transform.rotation * Quaternion.Euler(-max_eye_angle, max_eye_angle, 0) * Vector3.forward;
        //Vector3 see_left_down = this.transform.rotation * Quaternion.Euler(-max_eye_angle, -max_eye_angle, 0) * Vector3.forward;

        //Debug.DrawLine(this.transform.rotation * (see_direct_vec3 * min_eye_distance), this.transform.rotation * (see_direct_vec3*max_eye_distance), Color.blue);
        Debug.DrawLine(this.transform.rotation * (Vector3.forward * min_eye_distance), this.transform.rotation * (Vector3.forward * max_eye_distance), Color.blue);

        //Debug.DrawLine(see_right_up, see_right_down, Color.blue);

        //Debug.DrawLine(see_right_up * min_eye_distance, see_right_up * max_eye_distance * Mathf.Sqrt(2), Color.blue);
        //Debug.DrawLine(see_right_down * min_eye_distance, see_right_down * max_eye_distance * Mathf.Sqrt(2), Color.blue);
        //Debug.DrawLine(see_left_up * min_eye_distance, see_left_up * max_eye_distance * Mathf.Sqrt(2), Color.blue);
        //Debug.DrawLine(see_left_down * min_eye_distance, see_left_down * max_eye_distance * Mathf.Sqrt(2), Color.blue);

        //Debug.DrawLine(see_right_up * max_eye_distance * Mathf.Sqrt(2), see_right_down * max_eye_distance * Mathf.Sqrt(2), Color.blue);
        //Debug.DrawLine(see_right_down * max_eye_distance * Mathf.Sqrt(2), see_left_down * max_eye_distance * Mathf.Sqrt(2), Color.blue);
        //Debug.DrawLine(see_left_up * max_eye_distance * Mathf.Sqrt(2), see_right_up * max_eye_distance * Mathf.Sqrt(2), Color.blue);
        //Debug.DrawLine(see_left_down * max_eye_distance * Mathf.Sqrt(2), see_left_up * max_eye_distance * Mathf.Sqrt(2), Color.blue);

        //print(see_right_up );
        //print(see_right_up * min_eye_distance );
        //print(see_right_up * max_eye_distance);

        //Debug.DrawLine(see_right_up_max * min_eye_distance, see_right_up_max * max_eye_distance, Color.blue);
        //print(see_right_up_min + see_right_up_max);
        Debug.DrawLine(see_right_min * min_eye_distance, see_right_max * max_eye_distance, Color.blue);
        Debug.DrawLine(see_left_min * min_eye_distance, see_left_max * max_eye_distance, Color.blue);

        //Debug.DrawLine(see_right_max * max_eye_distance, this.transform.rotation * (Vector3.forward * max_eye_distance), Color.blue);
        //Debug.DrawLine(see_left_max * max_eye_distance, this.transform.rotation * (Vector3.forward * max_eye_distance), Color.blue);

        Debug.DrawLine(see_up_min * min_eye_distance, see_up_max * max_eye_distance, Color.blue);
        Debug.DrawLine(see_down_min * min_eye_distance, see_down_max * max_eye_distance, Color.blue);

        Debug.DrawLine(see_up_right_min * min_eye_distance, see_up_right_max * max_eye_distance, Color.blue);
        Debug.DrawLine(see_down_left_min * min_eye_distance, see_down_left_max * max_eye_distance, Color.blue);

        Debug.DrawLine(see_down_right_min * min_eye_distance, see_down_right_max * max_eye_distance, Color.blue);
        Debug.DrawLine(see_up_left_min * min_eye_distance, see_up_left_max * max_eye_distance, Color.blue);

        //print(see_up_left_max * max_eye_distance);

        //Debug.DrawLine(see_up_max * max_eye_distance, this.transform.rotation * (Vector3.forward * max_eye_distance), Color.blue);
        //Debug.DrawLine(see_down_max * max_eye_distance, this.transform.rotation * (Vector3.forward * max_eye_distance), Color.blue);

        //碰撞範圍
        //Vector3 vec3_45 = Quaternion.Euler(0f, 45f, 0f) * new Vector3(0, 0, max_eye_distance);
        //Vector3 vec3_135 = Quaternion.Euler(0f, 135f, 0f) * new Vector3(0, 0, max_eye_distance);
        //Vector3 vec3_225 = Quaternion.Euler(0f, 225f, 0f) * new Vector3(0, 0, max_eye_distance);
        //Vector3 vec3_315 = Quaternion.Euler(0f, 315f, 0f) * new Vector3(0, 0, max_eye_distance);

        //Debug.DrawLine(this.transform.position + new Vector3(max_eye_distance, 5, 0), this.transform.position + vec3_45 + new Vector3(0, 5, 0), Color.green);
        //Debug.DrawLine(this.transform.position + vec3_45 + new Vector3(0, 5, 0), this.transform.position + new Vector3(0,5, max_eye_distance), Color.green);
        //Debug.DrawLine(this.transform.position + new Vector3(0, 5, max_eye_distance), this.transform.position + vec3_315 + new Vector3(0, 5, 0), Color.green);
        //Debug.DrawLine(this.transform.position + vec3_315 + new Vector3(0, 5, 0), this.transform.position + new Vector3(-max_eye_distance, 5, 0), Color.green);
        //Debug.DrawLine(this.transform.position + new Vector3(-max_eye_distance, 5, 0), this.transform.position + vec3_225 + new Vector3(0, 5, 0), Color.green);
        //Debug.DrawLine(this.transform.position + vec3_225 + new Vector3(0, 5, 0), this.transform.position + new Vector3(0, 5, -max_eye_distance), Color.green);
        //Debug.DrawLine(this.transform.position + new Vector3(0, 5, -max_eye_distance), this.transform.position + vec3_135 + new Vector3(0, 5, 0), Color.green);
        //Debug.DrawLine(this.transform.position + vec3_135 + new Vector3(0, 5, 0), this.transform.position + new Vector3(max_eye_distance,5,0), Color.green);

        //Debug.DrawLine(this.transform.position + new Vector3(max_eye_distance, -5, 0), this.transform.position + vec3_45 + new Vector3(0, -5, 0), Color.green);
        //Debug.DrawLine(this.transform.position + vec3_45 + new Vector3(0, -5, 0), this.transform.position + new Vector3(0, -5, max_eye_distance), Color.green);
        //Debug.DrawLine(this.transform.position + new Vector3(0, -5, max_eye_distance), this.transform.position + vec3_315 + new Vector3(0, -5, 0), Color.green);
        //Debug.DrawLine(this.transform.position + vec3_315 + new Vector3(0, -5, 0), this.transform.position + new Vector3(-max_eye_distance, -5, 0), Color.green);
        //Debug.DrawLine(this.transform.position + new Vector3(-max_eye_distance, -5, 0), this.transform.position + vec3_225 + new Vector3(0, -5, 0), Color.green);
        //Debug.DrawLine(this.transform.position + vec3_225 + new Vector3(0, -5, 0), this.transform.position + new Vector3(0, -5, -max_eye_distance), Color.green);
        //Debug.DrawLine(this.transform.position + new Vector3(0, -5, -max_eye_distance), this.transform.position + vec3_135 + new Vector3(0, -5, 0), Color.green);
        //Debug.DrawLine(this.transform.position + vec3_135 + new Vector3(0, -5, 0), this.transform.position + new Vector3(max_eye_distance, -5, 0), Color.green);

        //Debug.DrawLine(this.transform.position + new Vector3(max_eye_distance, -5, 0), this.transform.position + new Vector3(max_eye_distance, 5, 0), Color.green);
        //Debug.DrawLine(this.transform.position + vec3_45 + new Vector3(0, -5, 0), this.transform.position + vec3_45 + new Vector3(0, 5, 0), Color.green);
        //Debug.DrawLine(this.transform.position + new Vector3(0, -5, max_eye_distance), this.transform.position + new Vector3(0, 5, max_eye_distance), Color.green);
        //Debug.DrawLine(this.transform.position + vec3_315 + new Vector3(0, -5, 0), this.transform.position + vec3_315 + new Vector3(0, 5, 0), Color.green);
        //Debug.DrawLine(this.transform.position + new Vector3(-max_eye_distance, -5, 0), this.transform.position + new Vector3(-max_eye_distance, 5, 0), Color.green);
        //Debug.DrawLine(this.transform.position + vec3_225 + new Vector3(0, -5, 0), this.transform.position + vec3_225 + new Vector3(0, 5, 0), Color.green);
        //Debug.DrawLine(this.transform.position + new Vector3(0, -5, -max_eye_distance), this.transform.position + new Vector3(0, 5, -max_eye_distance), Color.green);
        //Debug.DrawLine(this.transform.position + vec3_135 + new Vector3(0, -5, 0), this.transform.position + vec3_135 + new Vector3(0, 5, 0), Color.green);



    }

}
