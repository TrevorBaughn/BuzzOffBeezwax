using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMover : Mover
{
    protected override void Start()
    {
        base.Start();

        
    }

    public void MoveForward(float speed)
    {
        //move position of rigidbody rank forward at speed
        rigidbodyComponent.MovePosition(transform.position += (transform.up * (speed * Time.deltaTime)));
    }

    public void TurnTowards(Vector3 targetPos, float speed)
    {
        //find vector to target pos from pos
        Vector3 vectorToTargetPos = targetPos - transform.position;
        //find quaternion needed to look down vector
        Quaternion lookRot = Quaternion.LookRotation(transform.forward, vectorToTargetPos);
        //change rotation to be slightly down quaternion
        transform.rotation = Quaternion.RotateTowards(transform.rotation,
                                                      lookRot,
                                                      speed * Time.deltaTime);
    }
}
