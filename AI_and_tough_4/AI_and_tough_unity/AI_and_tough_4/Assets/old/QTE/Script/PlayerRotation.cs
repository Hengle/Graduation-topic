using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

	public Transform zhizhengRot;//指针的旋转中心点
	public float playerspeed;//黑球旋转速度
	public bool turn = true;//判断是否开始旋转的开关
	public Transform Mosnterpoint;//红球的旋转中心的
	public Transform circleDot;//轮盘圆心
	public GameObject mosntercheck;//附在红球身上，判断是否check的点
	public float mosnterspeed;//红球的旋转速度
	public GameObject checkpoi;//附在指针顶端的，判断是否check的点
	public float random;//速度随机变量




	// Use this for initialization
	void Start () 
	{
		//checkpoi.GetComponent<Check> ().enabled = false;
		checkpoi.SetActive (false);//将判断check的点关闭，待停止才出现，做判断是否check
		RanDom ();

	}
	
	// Update is called once per frame
	void Update () {
		
		//按下空格键后，check点会出现进行判断，再次按下check,轮盘开始旋转
		if (turn == true&&Input.GetKeyDown(KeyCode.Space))
		{
			turn = false;
			RanDom ();
			checkpoi.SetActive (true);
		}
		else if(Input.GetKeyDown(KeyCode.Space)){
			turn = true;			
			checkpoi.SetActive (false);
		}


		if (turn) //红球黑球旋转
		{
			zhizhengRot.RotateAround (circleDot.transform.position, circleDot.transform.up, playerspeed * Time.deltaTime);
			Mosnterpoint.RotateAround (circleDot.transform.position, circleDot.transform.up, random*50 * Time.deltaTime);
		}

	}

	//随机数
	void RanDom()
	{   
		random = Random.Range (-10, 10);
		if (random == 0 || random == 1) {
			random = Random.Range (-6, 6);
		} 
	}
		
}