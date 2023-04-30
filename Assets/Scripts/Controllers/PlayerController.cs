using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : Controller
{
    public PlayerPawn pawn;
    public int honey;

    // Start is called before the first frame update
    protected override void Start()
    {

        //add itself to list of players
        GameManager.instance.players.Add(this);

        pawn = GetComponent<PlayerPawn>();
    }
    protected override void OnDestroy()
    {
        //remove itself from list of players
        GameManager.instance.players.Remove(this);
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        if(pawn != null)
        {
            ProcessInputs();
        }
    }

    protected abstract void ProcessInputs();
}
