using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI honeyText;
    [SerializeField] private TextMeshProUGUI maxWaxText;
    private int maxHoney;

    private void Start()
    {

        SetMaxHoney();

        maxWaxText.text = maxHoney.ToString();
    }

    public void SetMaxHoney()
    {
        maxHoney = GameManager.instance.uiGameplay.maxHoney;
        

        maxWaxText.text = maxHoney.ToString();
    }

    public void UpdateHoneyScoreText()
    {
        if(GameManager.instance.players.Count > 0)
        {
            honeyText.text = GameManager.instance.players[0].honey.ToString();
        }
    }

    public void UpdateTimerText()
    {
        double doubleTimer = (double)GameManager.instance.deathTimer.timeTilDeath;
        doubleTimer = Math.Round(doubleTimer, 2);
        timerText.text = doubleTimer.ToString();
    }

    private void OnEnable()
    {
        SetMaxHoney();
        UpdateHoneyScoreText();
        UpdateTimerText();

        if (GameManager.instance.isBuzzOff)
        {
            foreach(BeezwaxObject beezwaxObject in GameManager.instance.beezwaxObjects)
            {
                beezwaxObject.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (BeezwaxObject beezwaxObject in GameManager.instance.beezwaxObjects)
            {
                beezwaxObject.gameObject.SetActive(true);
            }
        }
    }


    //Resets and restarts game
    public void RestartGameButton()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        GameManager.instance.ActivateGameplayState();
    }

    //returns to main menu
    public void MainMenuButton()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        GameManager.instance.ActivateMainMenuState();
    }

    //quits the game
    public void QuitGameButton()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        Application.Quit();
    }
}