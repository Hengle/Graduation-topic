using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoxelMax;

public class boob : MonoBehaviour {

    public float time = 1f;

    public VoxelBomb _VoxelBomb;

    // Use this for initialization
    void Start ()
    {
        _VoxelBomb.triggered = true;
    }
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;

        if(time <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
