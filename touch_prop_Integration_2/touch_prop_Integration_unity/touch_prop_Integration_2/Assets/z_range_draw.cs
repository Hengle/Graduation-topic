using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class z_range_draw : MonoBehaviour
{

    public GameObject game_1;

    public GameObject game_2;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(game_1.transform.position, new Vector3(game_2.transform.position.x, game_1.transform.position.y, game_1.transform.position.z),Color.black);
        Debug.DrawLine(game_1.transform.position, new Vector3(game_1.transform.position.x, game_2.transform.position.y, game_1.transform.position.z), Color.black);
        Debug.DrawLine(game_2.transform.position, new Vector3(game_1.transform.position.x, game_2.transform.position.y, game_1.transform.position.z), Color.black);
        Debug.DrawLine(game_2.transform.position, new Vector3(game_2.transform.position.x, game_1.transform.position.y, game_1.transform.position.z), Color.black);
    }
}
