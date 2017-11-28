using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE_angle_tough : MonoBehaviour
{
    /*
    //public swipe_2 _swipe_2;

    //public float angle;

    public GameObject ball;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void QTE_on(float angle_qte)
    //{
    //    if ((angle_qte < 22.5f) && (angle_qte > -22.5f))
    //    {
    //        GameObject ball_game = GameObject.Instantiate(ball, this.transform.position, Quaternion.identity);
    //        ball_game.transform.parent = this.transform;
    //        ball_game.GetComponent<ball>().vec3 = new Vector3(1, 0, 0);
    //    }
    //    else if ((angle_qte > 22.5f) && (angle_qte < 67.5f))
    //    {
    //        GameObject ball_game = GameObject.Instantiate(ball, this.transform.position, Quaternion.identity);
    //        ball_game.transform.parent = this.transform;
    //        ball_game.GetComponent<ball>().vec3 = new Vector3(1, 1, 0);
    //    }
    //    else if ((angle_qte > 67.5f) && (angle_qte < 112.5f))
    //    {
    //        GameObject ball_game = GameObject.Instantiate(ball, this.transform.position, Quaternion.identity);
    //        ball_game.transform.parent = this.transform;
    //        ball_game.GetComponent<ball>().vec3 = new Vector3(0, 1, 0);
    //    }
    //    else if ((angle_qte > 112.5f) && (angle_qte < 157.5f))
    //    {
    //        GameObject ball_game = GameObject.Instantiate(ball, this.transform.position, Quaternion.identity);
    //        ball_game.transform.parent = this.transform;
    //        ball_game.GetComponent<ball>().vec3 = new Vector3(-1, 1, 0);
    //    }
    //    else if (((angle_qte > 157.5) && (angle_qte < 180)) || ((angle_qte < -157.5) && (angle_qte > -180)))
    //    {
    //        GameObject ball_game = GameObject.Instantiate(ball, this.transform.position, Quaternion.identity);
    //        ball_game.transform.parent = this.transform;
    //        ball_game.GetComponent<ball>().vec3 = new Vector3(-1, 0, 0);
    //    }
    //    else if ((angle_qte > -157.5) && (angle_qte < -112.5f))
    //    {
    //        GameObject ball_game = GameObject.Instantiate(ball, this.transform.position, Quaternion.identity);
    //        ball_game.transform.parent = this.transform;
    //        ball_game.GetComponent<ball>().vec3 = new Vector3(-1, -1, 0);
    //    }
    //    else if ((angle_qte > -112.5f) && (angle_qte < -67.5f))
    //    {
    //        GameObject ball_game = GameObject.Instantiate(ball, this.transform.position, Quaternion.identity);
    //        ball_game.transform.parent = this.transform;
    //        ball_game.GetComponent<ball>().vec3 = new Vector3(0, -1, 0);
    //    }
    //    else if ((angle_qte > -67.5f) && (angle_qte < -22.5f))
    //    {
    //        GameObject ball_game = GameObject.Instantiate(ball, this.transform.position, Quaternion.identity);
    //        ball_game.transform.parent = this.transform;
    //        ball_game.GetComponent<ball>().vec3 = new Vector3(1, -1, 0);
    //    }


    //}

    public void QTE_on(Vector2 tough_vec)
    {
        GameObject ball_game = GameObject.Instantiate(ball, this.transform.position, Quaternion.identity);
        ball_game.transform.parent = this.transform;
        ball_game.GetComponent<ball>().vec3 = tough_vec;
    }
    */

    public enum bullet {yellow , puppole,green,blue };

    public bullet bullet_num;

}
