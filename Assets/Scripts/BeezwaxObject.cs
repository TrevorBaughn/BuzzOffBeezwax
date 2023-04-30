using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeezwaxObject : MonoBehaviour
{
    [SerializeField] private bool isDisabledOnStart;

    void Start()
    {
        GameManager.instance.beezwaxObjects.Add(this);

        if (isDisabledOnStart && GameManager.instance.isBuzzOff)
        {
            this.gameObject.SetActive(false);
        }
    }
}
