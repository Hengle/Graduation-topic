using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class move : MonoBehaviour {

    public NavMeshAgent agent;
    public Vector3 target;
    public Animator animator;

    public OffMeshLinkData link;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = transform.position;
        animator = GetComponent<Animator>();
        link = agent.currentOffMeshLinkData;
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0)&& Physics.Raycast(ray, out hit))
        {
            target = hit.point;
        }
        agent.SetDestination(target);
        animator.SetFloat("speed", agent.velocity.sqrMagnitude);

        //if (agent.isOnOffMeshLink == true)
        //{

        //    link = agent.currentOffMeshLinkData;
        //    this.gameObject.transform.position = Vector3.Lerp(link.startPos,link.endPos,10f);
        //    agent.enabled = false;
        //    agent.enabled = true;

        //    animator.SetBool("offMesh", true);
        //    animator.SetBool("offMesh", false);
        //}
        //if (agent.isOnOffMeshLink == true)
        //{
        //    this.gameObject.transform.position = link.endPos;
        //}
        //animator.SetBool("offMesh", false);

    }
}
