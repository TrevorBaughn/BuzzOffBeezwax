using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Mover : MonoBehaviour
{
    public Rigidbody2D rigidbodyComponent;

    protected virtual void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
    }

}
