using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_gameobject_all_manger : MonoBehaviour {

    public GameObject enemy;

    public NavMeshAgent enemy_nav;

    public Animator enemy_animator;


    private static AI_gameobject_all_manger _instance;

    public static AI_gameobject_all_manger instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }


}
