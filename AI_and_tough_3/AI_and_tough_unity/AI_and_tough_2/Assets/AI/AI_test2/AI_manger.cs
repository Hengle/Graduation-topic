using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_manger : MonoBehaviour {

    public Animator Ai_animator;

    public string AI_name_now;

    public float speed = 5f;

    public float q_speed = 100;

    public GameObject enemy;

    public bool see_wall = false;

    public float time;

    private static AI_manger _instance;

    public static AI_manger instance
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

    // Use this for initialization
    void Start () {
        Ai_animator = this.GetComponent<Animator>();
        time = Random.Range(3, 5);
    }
	
	// Update is called once per frame
	void Update () {
        //if (Ai_animator.GetCurrentAnimatorStateInfo(0).IsName("run") == true)
        //{
        //    print("test1");
        //}

        switch (AI_name_now)
        {
            case "work":
                //print("work");
                work();
                break;
            case "run":
                //print("run");
                run();
                break;
            default:
                print("not");
                break;
        }

        if(see_wall == true)
        {
            StartCoroutine(rotation());
        }

        if(time > 0 )
        {
            time -= Time.deltaTime;
            if(time <0)
            {
                time = Random.Range(3, 5);
                Ai_animator.SetBool("change_wolk_run", !Ai_animator.GetBool("change_wolk_run"));
            }
        }

    }


    void Animator_name(string name)
    {
        //print(name);
        AI_name_now = name;
    }

    void work()
    {
        enemy.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void run()
    {
        enemy.transform.Translate(Vector3.forward * speed * 2 * Time.deltaTime);
    }

    IEnumerator rotation()
    {
        enemy.transform.rotation =
                Quaternion.Euler(
                            0,
                            enemy.transform.rotation.eulerAngles.y + q_speed *Time.deltaTime,
                            0);
        yield return new WaitForSeconds(1);
        see_wall = false;
       
    }

}
