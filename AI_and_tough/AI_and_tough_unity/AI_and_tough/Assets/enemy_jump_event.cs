using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_jump_event : MonoBehaviour
{

    public AI_gameobject_all _AI_gameobject_all;

    public AI_tree_change_manger _AI_tree_change_manger;

    private void Awake()
    {
        _AI_gameobject_all = this.GetComponent<AI_gameobject_all>();
        _AI_tree_change_manger = this.GetComponent<AI_tree_change_manger>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
