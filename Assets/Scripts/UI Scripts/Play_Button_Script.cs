using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Play_Button_Script : MonoBehaviour {

    public Slider Slider;

    public void DoSomething()
{
    Debug.Log(Slider.value.ToString());
}
    public void DoSomethingElse(Slider slider_target)
    {
        Debug.Log(Slider.value.ToString());
    }
}
