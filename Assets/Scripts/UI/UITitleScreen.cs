using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITitleScreen : MonoBehaviour
{
    //button function to go to main menu
    public void MainMenuButton()
    {
        if (GameManager.instance != null)
        {
            AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
            GameManager.instance.ActivateMainMenuState();
        }
    }
}
