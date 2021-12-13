using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private int damage = 50;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private GameObject impactAnimation; // uncomment and add in unity once we have impactAnimation
    void Start()
    {
        rigidBody.velocity = transform.right * speed; // move rigid body to the LEFT with our speed
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    // This function will be called when our trigger hits something
    // hitInfo stores information on what we have hit
    {
        Debug.Log(hitInfo.name); // What did we hit
        PlayerHealth playerHealth = hitInfo.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            Instantiate(impactAnimation, transform.position, transform.rotation);
            playerHealth.TakeDamage(damage);
        }


        // uncomment and add in unity once we have impactAnimation
        Destroy(gameObject); // Destroy our bullet
    }

}
