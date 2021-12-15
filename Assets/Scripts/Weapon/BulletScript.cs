using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private int damage = 50;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private GameObject impactAnimation; // uncomment and add in unity once we have impactAnimation
    void Start()
    {
        rigidBody.velocity = transform.right * speed; // move rigid body to the right with our speed
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

    }

    void OnTriggerEnter2D(Collider2D hitInfo) 
    // This function will be called when our trigger hits something
    // hitInfo stores information on what we have hit
    {
        Debug.Log("We hit something:");
        Debug.Log(hitInfo.name); // What did we hit
        EnemySmart enemy = hitInfo.GetComponent<EnemySmart>();
        if (enemy != null)
        {
            Instantiate(impactAnimation, transform.position, transform.rotation);
            enemy.takeDamage(damage);
            Destroy(gameObject); // Destroy our bullet
        }


        // uncomment and add in unity once we have impactAnimation

    }

}
