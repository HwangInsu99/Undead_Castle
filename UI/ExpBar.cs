using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public Slider slider;

    public void SetMinEXP(float setMinEXP)
    {
        slider.minValue = setMinEXP;
        slider.value = setMinEXP;
    }

    public void SetMaxEXP(float setMaxEXP)
    {
        slider.maxValue = setMaxEXP;
        slider.value = setMaxEXP;
    }

    public void SetEXP(float setEXP)
    {
        slider.value = setEXP;
    }
}
