using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE_target_size : MonoBehaviour
{

    public RectTransform target_tr;

    public BoxCollider2D target_box;

    public float target_width_fiest;

    public float target_height_fiest;

    public float target_width_min;

    public float target_height_min;

    public float target_width_max;

    public float target_height_max;

    public float add_or_remove;

    //public float speed_width;

    //public float speed_height;

    public float speed = 5;

    //public float add_or_remove_time;

    // Use this for initialization
    void Start()
    {
        //add_or_remove_time = Random.Range(0f, 5f);
        add_or_remove = Random.Range(-1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        size_change();

    }

    void size_change()
    {
        //add_or_remove = Random.Range(-1f, 1f);

        //speed_width = Random.Range(1, 6);

        //speed_height = Random.Range(1, 6);

        //if (add_or_remove_time <= 0) 
        //{
        //    add_or_remove = Random.Range(-1, 2);
        //}

        if(add_or_remove == 0)
        {
            add_or_remove = Random.Range(-1, 2);
        }

        if ((target_tr.sizeDelta.x > target_width_max) || (target_tr.sizeDelta.y > target_height_max))
        {
            add_or_remove = Random.Range(-1, 0);
            //add_or_remove_time = Random.Range(0f, 5f);
        }
        else if ((target_tr.sizeDelta.x < target_width_min) || (target_tr.sizeDelta.y < target_height_min))
        {
            add_or_remove = Random.Range(0, 2);
            //add_or_remove_time = Random.Range(0f, 5f);
        }

        target_tr.sizeDelta = new Vector2(
            this.target_tr.sizeDelta.x + add_or_remove * speed ,
            this.target_tr.sizeDelta.y + add_or_remove * speed
            );

        target_box.size = new Vector2(
            this.target_box.size.x + add_or_remove * speed,
            this.target_box.size.y + add_or_remove * speed
            );

    }

}
