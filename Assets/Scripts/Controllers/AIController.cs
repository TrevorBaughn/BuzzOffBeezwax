using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIController : Controller
{
    [Header("AI State")]
    protected float timeEnteredCurrentState;
    public enum AIStates {Idle,Chase,ChooseTarget};
    public AIStates currentState;

    [SerializeField] protected GameObject AITarget;
    public BeePawn pawn;

    // Start is called before the first frame update
    protected override void Start()
    {
        //add itself to list of ais
        GameManager.instance.ais.Add(this);

        pawn = GetComponent<BeePawn>();
    }
    protected override void OnDestroy()
    {
        //remove itself from list of players
        GameManager.instance.ais.Remove(this);
    }

    protected abstract void MakeDecisions();

    public virtual void ChangeState(AIStates newState)
    {
        //remember change state time
        timeEnteredCurrentState = Time.time;
        //change state
        currentState = newState;
    }

    public virtual bool IsTimePassed(float amountOfTime)
    {
        if (Time.time - timeEnteredCurrentState >= amountOfTime)
        {
            return true;
        }
        return false;
    }

    ///<summary>
    /// POSSIBLE AI STATES BELOW
    ///</summary>
    ///

    protected void DoIdleState()
    {
        //move up
        if (!GameManager.instance.isBuzzOff)
        {
            pawn.moveSpeed = pawn.maxMoveSpeed;
            pawn.MoveForward();
            pawn.moveSpeed = pawn.baseMoveSpeed;
        }
    }
    protected void DoChaseState()
    {
        //turn towards and move towards the target
        pawn.TurnTowards(AITarget.transform.position);
        pawn.MoveForward();
    }
    protected void DoChooseTargetState()
    {
        //lock in choose target until a target is found
        while(AITarget == null)
        {
            if(GameManager.instance.players.Count > 0)
            {
                AITarget = GameManager.instance.players[0].gameObject;
            }
        }
    }

}
