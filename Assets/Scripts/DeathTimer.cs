using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTimer : MonoBehaviour
{
    public float timeToLive;
    public float timeTilDeath;

    // Start is called before the first frame update
    void Start()
    {
        timeTilDeath = timeToLive;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameplayCam.isActiveAndEnabled)
        {
            timeTilDeath -= Time.deltaTime;
            GameManager.instance.uiGameplay.UpdateTimerText();
            if (timeTilDeath <= 0)
            {
                timeTilDeath = 0;
                AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.timeUp);
                GameManager.instance.ActivateGameOverState();
            }
        } 
    }
}
