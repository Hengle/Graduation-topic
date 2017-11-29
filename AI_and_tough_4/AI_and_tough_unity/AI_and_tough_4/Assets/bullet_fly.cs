using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_fly : MonoBehaviour
{

    public Vector3 angle;

    public float speed;

    // Update is called once per frame
    void Update()
    {
        this.transform.position += angle * speed * Time.deltaTime;

    }

    public void angle_ins(Vector2 num)
    {
        angle = new Vector3(num.x, num.y, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }

}
