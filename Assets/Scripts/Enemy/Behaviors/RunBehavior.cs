using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunBehavior : StateMachineBehaviour
{
    [SerializeField]
    float speed;

    GameObject self;


    GameObject target;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        this.self = animator.gameObject;
        this.target = FindObjectOfType<PlayerBehavior>().gameObject;


    }

    // Update is called once per frame
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 selfTransform = new Vector2(this.self.transform.position.x, this.self.transform.position.y );
        Vector2 targetTransform = new Vector2(this.target.transform.position.x, this.target.transform.position.y );

        animator.SetFloat("distance", Vector2.Distance(selfTransform, targetTransform) );

        Vector2 vectorMoved = Vector2.MoveTowards( selfTransform , targetTransform, speed * 0.001f * -1);

        this.self.transform.position = new Vector3(vectorMoved.x, vectorMoved.y, this.self.transform.position.z );
    }
}
