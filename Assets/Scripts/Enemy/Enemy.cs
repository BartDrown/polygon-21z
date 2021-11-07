using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int attackDamage;

    //move
    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    private float moveSpeed = 2f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;

    [SerializeField] GameObject bullet;
    float fireRate;
    float nextFire;

    void Start()
    {
        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();
        fireRate = 1f;
        nextFire = Time.time;
    }

    void calcuateNewMovementVector()
    {
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * moveSpeed;
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

        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
        transform.position.y + (movementPerSecond.y * Time.deltaTime));

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
    /*
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.gameObject.name);
            Destroy(this.gameObject);
        }
        */
}
