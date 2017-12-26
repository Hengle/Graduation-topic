using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_fly : MonoBehaviour
{

    public Vector3 angle;

    public float speed;

    public value_test value_Test;

    private void Awake()
    {
        value_Test = (value_test)FindObjectOfType(typeof(value_test));
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += angle * speed /** Time.deltaTime*/;

    }

    public void angle_ins(Vector2 num)
    {
        angle = new Vector3(num.x, num.y, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "qte_target")
        {
            value_Test.value_on(this.gameObject.name.Substring(0,8));
        }

        Destroy(this.transform.parent.gameObject);
    }

}
