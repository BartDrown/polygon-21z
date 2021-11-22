using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform FirePoint;
    [SerializeField] private int health = 100;
    private float latestDirectionChangeTime = 0f;
    //time to change direction
    [SerializeField] private float directionChangeTime;
    [SerializeField] private float moveSpeed;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;

    [SerializeField] GameObject bullet;
    // [SerializeField] GameObject deathEffect; uncomment and add in unity once we have deathEffect
    [SerializeField] float fireRate;
    float nextFire;

    void Start()
    {
        nextFire = Time.time;
    }

    void Update()
    {

        CheckIfTimeToFire();

        //if the changeTime was reached, calculate a new movement vector
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calcuateNewMovementVector();
        }
        Move();
    }

    void Fire()
    {
        Instantiate(bullet, FirePoint.position, FirePoint.rotation);
        nextFire = Time.time + fireRate;
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Fire();
        }
    }

    void calcuateNewMovementVector()
    {
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * moveSpeed;
    }

    void Move()
    {
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
        transform.position.y + (movementPerSecond.y * Time.deltaTime));
    }

    public void takeDamage(int damage) // public because accessible by BulletScript.cs OnTriggerEnter2D()
    {
        health -= damage;
        if(health <= 0)
        {
            die();
        }
    }

    void die()
    {
        // Instantiate(deathEffect, transform.position, Quaternion.identity);
        // uncomment and add in unity once we have deathEffect
        Destroy(gameObject);
    }


}
