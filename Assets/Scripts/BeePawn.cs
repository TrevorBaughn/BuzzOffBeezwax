using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeePawn : Pawn
{
    public BeeMover mover;

    [Header("Turn Speeds")]
    public float maxTurnSpeed;
    public float baseTurnSpeed;
    public float turnSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        //load mover
        mover = GetComponent<BeeMover>();
    }

    public void MoveForward()
    {
        //use the mover to move forward if not null
        if (mover != null)
        {
            mover.MoveForward(moveSpeed);
        }
    }

    public void TurnTowards(Vector3 position)
    {
        mover.TurnTowards(position, turnSpeed);
    }

    
}
