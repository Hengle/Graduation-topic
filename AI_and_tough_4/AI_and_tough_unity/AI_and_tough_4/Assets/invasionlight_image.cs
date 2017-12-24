using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class invasionlight_image : MonoBehaviour {

    public Image back_image;

    //public Image check_image;

    public Toggle this_toggle;

    public void chack_()
    {
        if(this_toggle.isOn == true)
        {
            back_image.fillAmount = 0;
        }
        else
        {
            back_image.fillAmount = 1;
        }
    }
}
