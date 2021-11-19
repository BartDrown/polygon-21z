using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Allows us to create a variable that holds our slider

public class HealthBarScript : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void setValue(int health)  // Must be accessible from PlayerHealth.cs
    {
        slider.value = health;
    }

    public void setMaxValue(int maxHealth) // Must be accessible from PlayerHealth.cs
    {
        slider.maxValue = maxHealth;
        setValue(maxHealth);
    }

}
