using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  READ ME
 *  If we want to in the future write code that "flips the player" use transform.Rotate(0f, 180f, 0f) (x, y, z)
 *  This way point from which he shoots will also flip and they player will not shoot himself
 *  After writing check if FirePoint does flip
 */

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    float acceleration = 5f;

    [SerializeField]
    Vector2 bounds = new Vector2(10f, 15f);

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //? Transform player position according to input
        this.transform.position = new Vector3(
            horizontalInput * acceleration * Time.deltaTime + this.transform.position.x,
            verticalInput * acceleration * Time.deltaTime + this.transform.position.y,
            this.transform.position.z);

        //? Limit playerPawn to boundaries 
        this.transform.position = new Vector3(
            Mathf.Clamp(this.transform.position.x, -this.bounds.x, this.bounds.x),
            Mathf.Clamp(this.transform.position.y, -this.bounds.y, this.bounds.y),
            this.transform.position.z);

    }

    //? Bounds debug gizmo
    void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(this.bounds.x * 2, this.bounds.y * 2, 1));
    }
}
