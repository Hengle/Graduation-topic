using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class move_2 : MonoBehaviour {

    public NavMeshAgent agent;
    public Vector3 target;
    public Animator animator;

    public OffMeshLinkData link;

    public bool plane_bool = false;

    public GameObject ray_gameobject;

    public Vector3 plane_range;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        target = transform.position;
        animator = GetComponent<Animator>();
        link = agent.currentOffMeshLinkData;
        plane_range = new Vector3(Random.Range(-16.7f, 16.7f), 0, Random.Range(-16.7f, 16.7f));
    }

    // Update is called once per frame
    void Update () {
        Ray ray = new Ray(ray_gameobject.gameObject.transform.position, plane_range - ray_gameobject.gameObject.transform.position);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        Debug.DrawLine(ray_gameobject.gameObject.transform.position, plane_range, Color.cyan);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            target = hit.point;
        }

        if (plane_bool == true)
        {
            plane_range = new Vector3(Random.Range(-16.7f, 16.7f), 0, Random.Range(-16.7f, 16.7f));
            plane_bool = false;
        }


        agent.SetDestination(target);
        animator.SetFloat("speed", agent.velocity.sqrMagnitude);
    }
}
