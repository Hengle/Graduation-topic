using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour {

    public GameObject[] target;
    public float speed = 10;
    private float distanceToTarget;
    private bool move = true;

    public int num = 0;

    //public List<Vector3> aaa = new List<Vector3>();

    //public List<Vector3> bbb = new List<Vector3>();

    void Start()
    {
        distanceToTarget = Vector3.Distance(this.transform.position, target[num].transform.position);
        StartCoroutine(Shoot());
        //StartCoroutine(print_());
    }

    IEnumerator Shoot()
    {

        while (move)
        {
            //aaa.Add(this.transform.position);
            //bbb.Add(this.transform.rotation.eulerAngles);
            Vector3 targetPos = target[num].transform.position;
            //朝向目标  (Z轴朝向目标)  
            this.transform.LookAt(targetPos);
            //根据距离衰减 角度  
            float angle = Mathf.Min(1, Vector3.Distance(this.transform.position, targetPos) / distanceToTarget) * 45;
            //旋转对应的角度（线性插值一定角度，然后每帧绕X轴旋转）  
            this.transform.rotation = this.transform.rotation * Quaternion.Euler(Mathf.Clamp(-angle, -42, 42), 0, 0);
            //当前距离目标点  
            float currentDist = Vector3.Distance(this.transform.position, target[num].transform.position);
            if (currentDist < 0.5f)
            {
               if(num + 1 <= target.Length)
                {
                    num += 1;
                    distanceToTarget = Vector3.Distance(this.transform.position, target[num].transform.position);
                }
               else
                {
                    move = false;
                }
               
            }
            //平移 （朝向Z轴移动）  
            this.transform.Translate(Vector3.forward * Mathf.Min(speed * Time.deltaTime, currentDist));
            yield return null;
        }
    }

    //IEnumerator print_()
    //{
    //    for(int i = 0; i < aaa.Count;i++)
    //    {
    //        print(aaa[i]);
    //    }
    //    for (int i2 = 0; i2 < bbb.Count; i2++)
    //    {
    //        print(bbb[i2]);
    //    }
    //    yield return null;
    //}

}
