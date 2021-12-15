using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform FirePoint;
    [SerializeField] private GameObject bullet;

    private float lastTimeShot = 0f;
    void Update()
    {
        // To change this button go to
        // Unity -> Edit -> Project Settings -> Input Manager -> Fire1 -> AltPositiveButton
        // mouse 0 by default
        if (Input.GetButton("Fire1") && this.canShoot()) 
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bullet, FirePoint.position, FirePoint.rotation);
    }




    public void setBulletType(GameObject newBullet)
    {
        bullet = newBullet;
    }

    private bool canShoot(){
        float shootInterval = this.bullet.GetComponent<BulletScript>().getShootInterval();

        if(this.lastTimeShot < Time.time - shootInterval ){
            this.lastTimeShot = Time.time;
            return true;
        }
        return false;
    }
}
