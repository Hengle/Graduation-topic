using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class animator_event_off : MonoBehaviour {

    public UnityEvent off;

    public AI_look_event_manger _AI_look_event_manger;

    public void animator_off()
    {
        off.Invoke();
    }

    public void ai_look_off()
    {
        _AI_look_event_manger.is_on = false;
    }

}
