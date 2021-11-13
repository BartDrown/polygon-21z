using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform FirePoint;
    [SerializeField] private GameObject bullet;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        // To change this button go to
        // Unity -> Edit -> Project Settings -> Input Manager -> Fire1 -> AltPositiveButton
        // mouse 0 by default
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bullet, FirePoint.position, FirePoint.rotation);
    }
}
