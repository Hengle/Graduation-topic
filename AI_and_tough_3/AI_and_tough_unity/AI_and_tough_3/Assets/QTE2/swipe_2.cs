using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipe_2 : MonoBehaviour {

    private TextMesh textMesh;
    private GameObject trail;

    public Vector2 tough_vec2;

    public float angle;
    [Header("以30度為區間 也就是 -30~30為right 31~59為other")]
    public string news;

    public QTE_angle_tough _QTE_angle_tough;

    // Subscribe to events
    void OnEnable()
    {
        EasyTouch.On_SwipeStart += On_SwipeStart;
        EasyTouch.On_Swipe += On_Swipe;
        EasyTouch.On_SwipeEnd += On_SwipeEnd;
    }

    void OnDisable()
    {
        UnsubscribeEvent();
    }

    void OnDestroy()
    {
        UnsubscribeEvent();
    }

    void UnsubscribeEvent()
    {
        EasyTouch.On_SwipeStart -= On_SwipeStart;
        EasyTouch.On_Swipe -= On_Swipe;
        EasyTouch.On_SwipeEnd -= On_SwipeEnd;
    }

    void Start()
    {
        textMesh = GameObject.Find("LastSwipeText").transform.gameObject.GetComponent("TextMesh") as TextMesh;
    }

    // At the swipe beginning 
    private void On_SwipeStart(Gesture gesture)
    {

        // Only for the first finger
        if (gesture.fingerIndex == 0 && trail == null)
        {

            // the world coordinate from touch for z=5
            Vector3 position = gesture.GetTouchToWordlPoint(5);
            trail = Instantiate(Resources.Load("Trail"), position, Quaternion.identity) as GameObject;
        }
    }

    // During the swipe
    private void On_Swipe(Gesture gesture)
    {

        if (trail != null)
        {

            // the world coordinate from touch for z=5
            Vector3 position = gesture.GetTouchToWordlPoint(5);
            trail.transform.position = position;
        }
    }

    // At the swipe end 
    private void On_SwipeEnd(Gesture gesture)
    {

        if (trail != null)
        {
            Destroy(trail);

            // Get the swipe angle
            float angles = gesture.GetSwipeOrDragAngle();
            //textMesh.text = "Last swipe : " + gesture.swipe.ToString() + " /  vector : " + gesture.swipeVector.normalized + " / angle : " + angles.ToString("f2") + " / " + gesture.deltaPosition.x.ToString("f5");

            news = gesture.swipe.ToString();
            tough_vec2 = gesture.swipeVector.normalized;
            angle = angles;

            _QTE_angle_tough.QTE_on(angle);
        }

    }

    public void angle_end()
    {
        news = "";
        tough_vec2 = Vector2.zero;
        angle = 0;
    }

}
