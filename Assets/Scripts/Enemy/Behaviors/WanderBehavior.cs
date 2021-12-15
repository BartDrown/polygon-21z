using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehavior : StateMachineBehaviour
{
    [SerializeField]
    float speed;

    GameObject self;


    GameObject target;

    Vector2 randomTarget;

    [SerializeField]
    float wanderXDistance, wanderYDistance;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        
        this.self = animator.gameObject;
        this.target = FindObjectOfType<PlayerBehavior>().gameObject;

        Vector2 randomTarget = new Vector2(Random.Range(this.self.transform.position.x - wanderXDistance, this.self.transform.position.x + wanderXDistance),
                                           Random.Range(this.self.transform.position.y - wanderYDistance, this.self.transform.position.y + wanderYDistance));
    }

    // Update is called once per frame
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 selfTransform = new Vector2(this.self.transform.position.x, this.self.transform.position.y );
        Vector2 targetTransform = new Vector2(this.target.transform.position.x, this.target.transform.position.y );

        animator.SetFloat("distance", Vector2.Distance(selfTransform, targetTransform) );
        
        if(Mathf.Abs(selfTransform.x - randomTarget.x) < 0.1f && Mathf.Abs(selfTransform.y - randomTarget.y) < 0.1f  ){
            Vector2 randomTarget = new Vector2(Random.Range(this.self.transform.position.x - wanderXDistance, this.self.transform.position.x + wanderXDistance),
                                               Random.Range(this.self.transform.position.y - wanderYDistance, this.self.transform.position.y + wanderYDistance));
        }


        Vector2 vectorMoved = Vector2.MoveTowards( selfTransform , randomTarget , speed * 0.001f);

        this.self.transform.position = new Vector3(vectorMoved.x, vectorMoved.y, this.self.transform.position.z );
    }
}
