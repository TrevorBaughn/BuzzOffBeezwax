using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIGameplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI honeyText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Image waxImage;
    [SerializeField] private TextMeshProUGUI maxWaxText;
    public int maxHoney;

    private void Start()
    {

        SetMaxHoney();
        UpdateWaxImage();
    }

    public void SetMaxHoney()
    {
        maxHoney = 0;
        foreach (Beehive hive in GameManager.instance.hives)
        {
            if (hive.isActiveAndEnabled)
            {
                maxHoney += hive.baseHoney;
            }
        }

        maxWaxText.text = maxHoney.ToString();
        UpdateWaxImage();
    }


    // Update is called once per frame
    public void UpdateWaxImage()
    {
        if(GameManager.instance.players.Count > 0)
            waxImage.fillAmount = (float)GameManager.instance.players[0].honey / maxHoney;
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

}
