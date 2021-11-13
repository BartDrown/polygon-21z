using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Allows us to create a variable that holds our slider

public class HealthBarScript : MonoBehaviour
{
    public Slider slider;

    public void setValue(int health) 
    {
        slider.value = health;
    }

    public void setMaxValue(int maxHealth)
    {
        slider.maxValue = maxHealth;
        setValue(maxHealth);
    }

}
