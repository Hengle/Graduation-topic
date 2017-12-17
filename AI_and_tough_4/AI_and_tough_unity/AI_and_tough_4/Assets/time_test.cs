using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time_test : MonoBehaviour {

    public CanvasGroup canvasGroup;

    public float time;

    public float time2;

    // Use this for initialization
    void Start () {
        time2 = Time.realtimeSinceStartup - time;
        time = Time.realtimeSinceStartup;
    }

    private void Update()
    {
        time2 = Time.realtimeSinceStartup - time;
        time = Time.realtimeSinceStartup;
        print("Update");
        print(canvasGroup.alpha + " " + Time.realtimeSinceStartup);
        canvasGroup.alpha += 0.1f *time2;
        
    }

    private void FixedUpdate()
    {
        print("FixedUpdate");
    }

    private void LateUpdate()
    {
        print("LateUpdate");
       
    }

    void OnEnable()
    {
        //時間暫停
        Time.timeScale = 0f;

    }

    void OnDisable()
    {
        //時間以正常速度運行
        Time.timeScale = 1f;
    }
}
