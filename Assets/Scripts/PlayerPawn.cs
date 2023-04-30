using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPawn : Pawn
{
    public bool isInteracting = false;
    private PlayerMover mover;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    private void Start()
    {
        //load mover
        mover = GetComponent<PlayerMover>();
    }

    public void MoveForward()
    {
        //use the mover to move forward if not null
        if (mover != null)
        {
            mover.MoveForward(moveSpeed);
        }
    }
    public void MoveBackward()
    {
        //use the mover to move backward if not null
        if (mover != null)
        {
            mover.MoveForward(-moveSpeed);
        }
    }
    public void MoveRight()
    {
        //use the mover to move backward if not null
        if (mover != null)
        {
            mover.MoveRight(moveSpeed);
        }
    }
    public void MoveLeft()
    {
        //use the mover to move backward if not null
        if (mover != null)
        {
            mover.MoveRight(-moveSpeed);
        }
    }
}
