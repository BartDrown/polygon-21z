using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmart : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] GameObject deathEffect; // uncomment and add in unity once we have deathEffect

    void Start()
    {
    }

    void Update()
    {

    }


    public void takeDamage(int damage) // public because accessible by BulletScript.cs OnTriggerEnter2D()
    {
        health -= damage;
        if (health <= 0)
        {
            die();
        }
    }

    void die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        // uncomment and add in unity once we have deathEffect
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }


}
