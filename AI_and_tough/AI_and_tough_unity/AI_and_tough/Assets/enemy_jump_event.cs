using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_jump_event : MonoBehaviour
{

    public AI_gameobject_all _AI_gameobject_all;

    public AI_tree_change_manger _AI_tree_change_manger;

    public GameObject enemy_game;

    public Vector3 start_pos;

    public GameObject star_game;

    public bezia_static _bezia_static;

    public bool static_ok;

    public Vector3[] jump_vec3;

    public int num = 0;

    private void Awake()
    {
        _AI_gameobject_all = this.GetComponent<AI_gameobject_all>();
        _AI_tree_change_manger = this.GetComponent<AI_tree_change_manger>();
        enemy_game = _AI_gameobject_all.enemy;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void check_gameobject()
    {
        if(static_ok == true)
        {
            enemy_jump_go();
        }

        if(jump_vec3 != null)
        {
            static_ok = true;
        }


        Ray ray = new Ray(this.gameObject.transform.position, start_pos - this.gameObject.transform.position);
        //Debug.DrawLine(this.gameObject.transform.position, start_pos,Color.red);
        Debug.DrawRay(ray.origin, ray.direction, Color.black);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1 << LayerMask.NameToLayer("jump_rull")))
        {
            star_game = hit.collider.gameObject;
            _bezia_static = hit.collider.gameObject.transform.parent.GetComponent<bezia_static>();
            jump_vec3 = new Vector3[_bezia_static.segmentNum];
        }

        if (Mathf.Abs(Vector3.Distance(start_pos, _bezia_static.path[0])) < 3f)
        {
            for (int i = 0; i < _bezia_static.path.Length; i++)
            {
                jump_vec3[i] = _bezia_static.path[i];
            }
        }
        else if (Mathf.Abs(Vector3.Distance(start_pos, _bezia_static.path[_bezia_static.path.Length - 1])) < 3f)
        {
            for (int i = _bezia_static.path.Length - 1; i >= 0; i--)
            {
                jump_vec3[_bezia_static.path.Length - 1 - i] = _bezia_static.path[i];
            }
        }

    }

    void enemy_jump_go()
    {
        if (Vector3.Distance(enemy_game.transform.position, jump_vec3[num]) < 0.1f) 
        {
            num++;
        }

        //enemy_game.transform.position = jump_vec3[num];
        enemy_game.transform.position = Vector3.Lerp(enemy_game.transform.position, jump_vec3[num],10f);
    }


}
