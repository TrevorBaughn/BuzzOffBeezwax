using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControls : MonoBehaviour
{
    //button function to go to main menu
    public void MainMenuButton()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        GameManager.instance.ActivateMainMenuState();
    }

    public void Update()
    {
        //back to main menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
            GameManager.instance.ActivateMainMenuState();
        }
    }
}
