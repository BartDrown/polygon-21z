using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100; // Nie daje const bo nie wiem czy nie b�dziemy max healtha zmienia�
    [SerializeField] private int currentHealth;

    [SerializeField] private HealthBarScript healthBar;

    void setPlayerHealthToValue(int valueToBeSet)
    {
        currentHealth = maxHealth;
        healthBar.setMaxValue(maxHealth);
    }


    void Start()
    {
        setPlayerHealthToValue(maxHealth);
    }
    
    void DEBUG_removeHpOnSpace(int damage) // originally to check slider functionality
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(damage);
        }
    }

    void Update()
    {
        DEBUG_removeHpOnSpace(20);
    }

    void TakeDamage(int damage)
    {
        if (currentHealth - damage < 0)
        {
            currentHealth = 0;
            healthBar.setValue(currentHealth);
        }
        else
        {
            currentHealth -= damage;
            healthBar.setValue(currentHealth);
        }
    }


}