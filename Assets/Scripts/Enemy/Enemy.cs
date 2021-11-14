using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // move variaable
    private float latestDirectionChangeTime = 0f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    [Header("Movement")]
    [SerializeField] private float directionChangeTime; //time to change direction
    [SerializeField] private float moveSpeed;


    // shoot variaable
    [Header("Shooting")]
    [SerializeField] GameObject bullet;
    public float startTimeBtwShots;
    public float currentShoot, maxShoot, reloadTime;

    private float timeBtwShots;
    private bool isReloading = false;

    void Start()
    {
        timeBtwShots = startTimeBtwShots;
        currentShoot = maxShoot;
    }

    void Update()
    {
        //if the changeTime was reached, calculate a new movement vector
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calcuateNewMovementVector();
        }

        if (currentShoot <= 0)
        {
            StartCoroutine(Reload());
        }

        if (!isReloading)
        {
            Fire();
        }

        Move();
    }

    void Fire()
    {

        if (timeBtwShots <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            currentShoot--;
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentShoot = maxShoot;
        isReloading = false;
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


}
