using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixBuzzOff : MonoBehaviour
{
    [SerializeField] private Beehive hive;

    // Start is called before the first frame update
    void OnEnable()
    {
        if (GameManager.instance.isBuzzOff)
        {
            hive.SpawnBee();
            GameManager.instance.SetBuzzOff();
        }
        else
        {
            GameManager.instance.SetBeezwaxBusiness();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
