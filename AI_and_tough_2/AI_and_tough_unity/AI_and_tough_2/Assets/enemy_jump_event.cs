using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_jump_event : MonoBehaviour
{

    public AI_gameobject_all _AI_gameobject_all;

    public AI_tree_change_manger _AI_tree_change_manger;

    public enemy_move_event _enemy_move_event;

    //public UnityEngine.AI.NavMeshAgent enemy_navmeshagent;

    [Header("跳躍腳本")]

    [Header("跳躍方塊Layer")]
    public LayerMask ray_layer;
    [Header("角色")]
    public GameObject enemy_game;
    [Header("起點")]
    public Vector3 start_pos;
    [Header("終點")]
    public Vector3 end_pos;
    [Header("起點物件")]
    public GameObject star_game;
    [Header("貝茲腳本")]
    public bezia_static _bezia_static;
    [Header("數值是否計算完")]
    public bool static_ok;

    //public Vector3[] jump_vec3;
    [Header("跳躍軌道")]
    public List<Vector3> jump_vec3 = new List<Vector3>();
    [Header("陣列位置")]
    public int num = 0;

    private void Awake()
    {
        _AI_gameobject_all = this.GetComponent<AI_gameobject_all>();
        _AI_tree_change_manger = this.GetComponent<AI_tree_change_manger>();
        _enemy_move_event = this.GetComponent<enemy_move_event>();
        enemy_game = _AI_gameobject_all.enemy;
        //enemy_navmeshagent = _AI_gameobject_all.enemy_nav;
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

        if (static_ok == true)
        {
            enemy_jump_go();
        }
        else
        {
            Ray ray = new Ray(this.gameObject.transform.position, start_pos - this.gameObject.transform.position);
            //Debug.DrawLine(this.gameObject.transform.position, start_pos,Color.red);
            Debug.DrawRay(ray.origin, ray.direction, Color.black);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, /*1 << LayerMask.NameToLayer("jump_rull")*/ray_layer.value)) 
            {
                star_game = hit.collider.gameObject;
                _bezia_static = hit.collider.gameObject.transform.parent.GetComponent<bezia_static>();
                //jump_vec3 = new Vector3[_bezia_static.segmentNum];
            }

            if (Mathf.Abs(Vector3.Distance(start_pos, _bezia_static.path[0])) < 3f)
            {
                jump_vec3.Add(start_pos);
                for (int i = 0; i < _bezia_static.path.Length; i++)
                {
                    //jump_vec3[i] = _bezia_static.path[i];
                    jump_vec3.Add(_bezia_static.path[i]);
                }
                jump_vec3.Add(end_pos);
            }
            else if (Mathf.Abs(Vector3.Distance(start_pos, _bezia_static.path[_bezia_static.path.Length - 1])) < 3f)
            {
                jump_vec3.Add(start_pos);
                for (int i = _bezia_static.path.Length - 1; i >= 0; i--)
                {
                    //jump_vec3[_bezia_static.path.Length - 1 - i] = _bezia_static.path[i];
                    jump_vec3.Add(_bezia_static.path[i]);
                }
                jump_vec3.Add(end_pos);
            }


            static_ok = true;

        }

    }

    void enemy_jump_go()
    {
        if ((Vector3.Distance(enemy_game.transform.position, jump_vec3[num]) < 0.1f) &&(num < (jump_vec3.Count-1)))
        {
            num++;
        }

        //enemy_game.transform.position = jump_vec3[num];
        enemy_game.transform.position = Vector3.Lerp(enemy_game.transform.position, jump_vec3[num],10f);

        if(num == (jump_vec3.Count - 1))
        {
            //enemy_navmeshagent.enabled = true;
            jump_off();
            _enemy_move_event.enemy_navmeshagent.enabled = true;
            _enemy_move_event.is_jump = false;
            _AI_tree_change_manger.change_animator_name("jump", false);
            _AI_tree_change_manger.change_animator_name("walk", true);
            _AI_tree_change_manger.change_animator_name("run", false);
        }
    }

   public  void jump_off()
    {
        start_pos = new Vector3();
        end_pos = new Vector3();
        star_game = null;
        static_ok = false;
        jump_vec3.Clear();
        num = 0;
    }

}
