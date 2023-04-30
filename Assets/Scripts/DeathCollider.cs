using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if player
        if(GameManager.instance.players.Count > 0)
        {
            if (collision.gameObject == GameManager.instance.players[0].gameObject)
            {
                //kill
                AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.sting);
                GameManager.instance.ActivateGameOverState();
            }
        }
        
    }
}
