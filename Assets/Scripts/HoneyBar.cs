using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoneyBar : MonoBehaviour
{
    public Image honeyImage;
    public Beehive hive;

    // Update is called once per frame
    public void UpdateHoneyImage()
    {
        honeyImage.fillAmount = (float)hive.honey / hive.maxHoney;
    }

}
