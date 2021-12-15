using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehavior : StateMachineBehaviour
{
    [SerializeField] GameObject bullet;
    // [SerializeField] GameObject deathEffect; uncomment and add in unity once we have deathEffect
    [SerializeField] float fireRate;
    float nextFire;

    [SerializeField] private Transform FirePoint;

    GameObject target; 
    GameObject self;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.self = animator.gameObject;
        target = FindObjectOfType<PlayerBehavior>().gameObject;

        nextFire = Time.time;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       CheckIfTimeToFire();
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Fire();
        }
    }

    void Fire()
    {
        float AngleRad = Mathf.Atan2(target.transform.position.y - self.transform.position.y, target.transform.position.x - self.transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;


        Debug.Log("FIORE");
        Instantiate(bullet, this.self.transform.position, Quaternion.Euler(0, 0, AngleDeg));
        nextFire = Time.time + fireRate;
    }

}
