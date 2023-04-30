using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //static (stays same) game manager instance
    public static GameManager instance;
    public static AudioManager audioManager;

    public Camera gameplayCam;

    public UIGameplay uiGameplay;
    public DeathTimer deathTimer;
    public bool isBuzzOff;

    [Header("Lists")]
    public List<PlayerController> players;
    public List<AIController> ais;
    public List<Beehive> hives;
    public List<BeezwaxObject> beezwaxObjects;


    [Header("Screen State Objects")]
    [SerializeField] private GameObject titleScreenStateObject;
    [SerializeField] private GameObject gameOverStateObject;
    [SerializeField] private GameObject mainMenuStateObject;
    [SerializeField] private GameObject optionsStateObject;
    [SerializeField] private GameObject controlsStateObject;
    [SerializeField] private GameObject creditsGameObject;
    [SerializeField] private GameObject gameplayStateObject;

    [Header("Winstate Text")]
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject youWinText;

    //Awake is called before Start
    private void Awake()
    {
        if (instance == null)
        {
            //this is THE game manager
            instance = this;
            //don't kill it in a new scene.
            DontDestroyOnLoad(gameObject);
        }
        else //this isn't THE game manager
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameplayCam.gameObject.SetActive(false);
        ActivateTitleScreenState();

        //attach audiomanager to gamemanager
        audioManager = AudioManager.instance;
    }

    private void ResetGame()
    {
        youWinText.SetActive(false);
        gameOverText.SetActive(true);

        foreach (PlayerController player in players)
        {
            player.honey = 0;
            player.gameObject.transform.position = new Vector3(0, -5, 0);
            player.pawn.moveSpeed = player.pawn.baseMoveSpeed;
        }

        foreach(Beehive hive in hives)
        {
            hive.honey = hive.baseHoney;
            hive.regenTimer = hive.timeToRegen;
            hive.collectTimer = hive.timeToCollect;
            hive.isPlayerInside = false;
            hive.hasBeeSpawned = false;
        }

        if (isBuzzOff == true)
        {
            SetBuzzOff();
        }
        else
        {
            SetBeezwaxBusiness();
        }

        deathTimer.timeTilDeath = deathTimer.timeToLive;

        uiGameplay.UpdateWaxImage();
        uiGameplay.UpdateHoneyScoreText();
        uiGameplay.UpdateTimerText();

        
    }

    [SerializeField] private int boMaxHoney;
    [SerializeField] private int boBaseHoney;
    [SerializeField] private int boHoneyRegen;
    [SerializeField] private float boTimeToRegen;
    public void SetBuzzOff()
    {
        foreach (BeezwaxObject beezwaxObject in beezwaxObjects)
        {
            beezwaxObject.gameObject.SetActive(false);
        }

        foreach(Beehive hive in hives)
        {
            hive.maxHoney = boMaxHoney;
            hive.baseHoney = boBaseHoney;
            hive.honey = boBaseHoney;
            hive.honeyToRegen = boHoneyRegen;
            hive.regenTimer = boTimeToRegen;

        }
    }

    [SerializeField] private int bbMaxHoney;
    [SerializeField] private int bbBaseHoney;


    public void SetBeezwaxBusiness()
    {
        foreach (BeezwaxObject beezwaxObject in beezwaxObjects)
        {
            beezwaxObject.gameObject.SetActive(true);
        }

        foreach (Beehive hive in hives)
        {
            hive.maxHoney = bbMaxHoney;
            hive.baseHoney = bbBaseHoney;
            hive.honey = bbBaseHoney;
            hive.honeyToRegen = 0;
            hive.timeToRegen = 0;
        }

        uiGameplay.SetMaxHoney();
    }


    public void CheckForWin()
    {
        int deadHives = 0;
        foreach (Beehive hive in hives)
        {
            if(hive.honey <= 0)
            {
                deadHives++;
            }
        }
        if(deadHives >= hives.Count)
        {
            //win

            ActivateGameOverState();
            youWinText.SetActive(true);
            gameOverText.SetActive(false);


        }


    }

    public bool hasActivatedOnce = false;
    //deactivate all gamestates
    private void DeactivateAllStates()
    {
        titleScreenStateObject.SetActive(false);
        gameOverStateObject.SetActive(false);
        mainMenuStateObject.SetActive(false);
        optionsStateObject.SetActive(false);
        if(hasActivatedOnce == true)
        {
            gameplayStateObject.SetActive(false);
        }

        controlsStateObject.SetActive(false);
        creditsGameObject.SetActive(false);
    }

    public void ActivateTitleScreenState()
    {
        DeactivateAllStates();
        titleScreenStateObject.SetActive(true);
    }

    public void ActivateGameOverState()
    {
        DeactivateAllStates();
        gameOverStateObject.SetActive(true);
    }

    public void ActivateMainMenuState()
    {
        DeactivateAllStates();
        mainMenuStateObject.SetActive(true);
    }

    public void ActivateOptionsState()
    {
        DeactivateAllStates();
        optionsStateObject.SetActive(true);
    }

    public void ActivateControlsState()
    {
        DeactivateAllStates();
        controlsStateObject.SetActive(true);
    }

    public void ActivateCreditsState()
    {
        DeactivateAllStates();
        creditsGameObject.SetActive(true);
    }

    public void ActivateGameplayState()
    {
        ResetGame();
        DeactivateAllStates();
        
        gameplayStateObject.SetActive(true);
        gameplayCam.gameObject.SetActive(true);
        uiGameplay.SetMaxHoney();
        

    }
}
