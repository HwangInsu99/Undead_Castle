using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(float setMaxHealth)
    {
        slider.maxValue = setMaxHealth;
        slider.value = setMaxHealth;
    }

    public void SetHealth(float setHealth)
    {
        slider.value = setHealth;
    }
}
