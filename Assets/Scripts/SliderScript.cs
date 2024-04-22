using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    private Slider slider;
    public int colorIndex = 0;
    private ColorManager sceneScript;

    void Start()
    {
        sceneScript = GameObject.Find("ColorManager").GetComponent<ColorManager>();
        slider = gameObject.GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    public void ValueChangeCheck()
    {
        sceneScript.ChangePlayerColor(colorIndex, slider.value);
    }
}