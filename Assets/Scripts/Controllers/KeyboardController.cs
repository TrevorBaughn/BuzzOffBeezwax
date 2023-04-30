using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : PlayerController
{
    [Header("Control Key Codes")]
    [SerializeField] private KeyCode moveUp;
    [SerializeField] private KeyCode moveLeft;
    [SerializeField] private KeyCode moveDown;
    [SerializeField] private KeyCode moveRight;
    [SerializeField] private KeyCode halfSpeed;
    [SerializeField] private KeyCode interact;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

       
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void Update()
    {
        ProcessInteraction();
    }

    void ProcessInteraction()
    {
        if (Input.GetKeyDown(interact))
        {
            pawn.isInteracting = true;
        }
        if (Input.GetKeyUp(interact))
        {
            pawn.isInteracting = false;
        }

        //and half-speed too
        if (Input.GetKeyDown(halfSpeed))
        {

            pawn.moveSpeed = pawn.minMoveSpeed;
        }
        if (Input.GetKeyUp(halfSpeed))
        {
            pawn.moveSpeed = pawn.baseMoveSpeed;
        }
    }

    protected override void ProcessInputs()
    {
        if (Input.GetKey(moveUp))
        {
            pawn.MoveForward();
        }
        if (Input.GetKey(moveDown))
        {
            pawn.MoveBackward();
        }
        if (Input.GetKey(moveRight))
        {
            pawn.MoveRight();
            pawn.sprite.flipX = false;
        }
        if (Input.GetKey(moveLeft))
        {
            pawn.MoveLeft();
            pawn.sprite.flipX = true;
        }
        
        
    }
}
