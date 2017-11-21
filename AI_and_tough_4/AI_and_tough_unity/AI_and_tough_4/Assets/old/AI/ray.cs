using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ray : MonoBehaviour {

    //   public Vector3 plane_range;

    //   public Vector3 target;

    //   public bool plane_bool=false;

    //   // Use this for initialization
    //   void Start ()
    //   {
    //       plane_range = new Vector3(Random.Range(-16.7f, 16.7f), 0, Random.Range(-16.7f, 16.7f));
    //   }

    //// Update is called once per frame
    //void Update ()
    //   {
    //       Ray ray = new Ray(this.gameObject.transform.position, plane_range - this.gameObject.transform.position);
    //       Debug.DrawRay(ray.origin,ray.direction,Color.red);
    //       Debug.DrawLine(this.gameObject.transform.position, plane_range, Color.cyan);
    //       RaycastHit hit;
    //       if (Physics.Raycast(ray, out hit))
    //       {
    //           target = hit.point;
    //       }

    //       if(plane_bool == true)
    //       {
    //           plane_range = new Vector3(Random.Range(-16.7f, 16.7f), 0, Random.Range(-16.7f, 16.7f));
    //           plane_bool = false;
    //       }
    //   }

    //public NavMeshAgent agent;
    public Vector3 target;
    //public Animator animator;

    //public OffMeshLinkData link;

    //public Vector3 plane_range;

    //public bool plane_bool = false;

    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        target = transform.position;
        //animator = GetComponent<Animator>();
        //link = agent.currentOffMeshLinkData;
        //plane_range = new Vector3(Random.Range(-16.7f, 16.7f), 0, Random.Range(-16.7f, 16.7f));
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButton(0) &&Physics.Raycast(ray, out hit, 1 << LayerMask.NameToLayer("ray")))
        {
            target = hit.point;
            print(hit.collider.gameObject.name);
        }

        //Ray ray = new Ray(this.gameObject.transform.position, plane_range - this.gameObject.transform.position);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        Debug.DrawLine(this.gameObject.transform.position, target, Color.cyan);
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit))
        //{
        //    target = hit.point;
        //}

        //if (plane_bool == true)
        //{
        //    plane_range = new Vector3(Random.Range(-16.7f, 16.7f), 0, Random.Range(-16.7f, 16.7f));
        //    plane_bool = false;
        //}


        //agent.SetDestination(target);
        //animator.SetFloat("speed", agent.velocity.sqrMagnitude);

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
