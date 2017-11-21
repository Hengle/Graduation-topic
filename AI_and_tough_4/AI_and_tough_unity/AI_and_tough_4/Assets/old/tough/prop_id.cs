using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prop_id : MonoBehaviour
{
    public enum prop_performance { press , click , delay }

    //道具使用規則press 長按 X 秒 , click 點擊立刻使用 , delay 點擊後延遲 X 秒
    [Header("道具使用規則")]
    [Header("press 長按 X 秒 , click 點擊立刻使用 , delay 點擊後延遲 X 秒")]
    public prop_performance prop_string;

    //道具使用秒數
    [Header("道具使用秒數 ， click 無效")]
    public float prop_time = 0;

}
