using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody2D rigidBody;
    void Start()
    {
        rigidBody.velocity = transform.right * speed; // move rigid body to the right with our speed
    }

    void OnTriggerEnter2D(Collider2D hitInfo) 
    // This function will be called when our trigger hits something
    // hitInfo stores information on what we have hit
    {
        Debug.Log(hitInfo.name); // What did we hit
        Destroy(gameObject); // Destroy our bullet
    }

}
