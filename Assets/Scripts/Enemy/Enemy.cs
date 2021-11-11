using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int attackDamage;


    private float latestDirectionChangeTime;
    [SerializeField] private float directionChangeTime;

    [SerializeField] private float moveSpeed;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;

    [SerializeField] GameObject bullet;
    [SerializeField] float fireRate;
    float nextFire;

    void Start()
    {
        latestDirectionChangeTime = 0f;
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

    void calcuateNewMovementVector()
    {
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * moveSpeed;
    }

    void Fire()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
        nextFire = Time.time + fireRate;
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Fire();
        }
    }

    void Move()
    {
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
        transform.position.y + (movementPerSecond.y * Time.deltaTime));
    }


}
