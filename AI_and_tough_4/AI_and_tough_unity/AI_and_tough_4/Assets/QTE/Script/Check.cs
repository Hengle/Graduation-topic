using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour {


	void Update(){




	}


	int sum = 0;
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "high")
		{
			sum++;
			print ("check up"+sum);

		}

	}

}