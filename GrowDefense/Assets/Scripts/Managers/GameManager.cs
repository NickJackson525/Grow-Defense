﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    #region Variables

    #region Conrols Dictionary

    public Dictionary<ControlScheme, Dictionary<Direction, KeyCode>> Controls = new Dictionary<ControlScheme, Dictionary<Direction, KeyCode>>()
    {
        {
            ControlScheme.WASD, new Dictionary<Direction, KeyCode>
            {
                {Direction.UP, KeyCode.W},
                {Direction.DOWN, KeyCode.S},
                {Direction.LEFT, KeyCode.A},
                {Direction.RIGHT, KeyCode.D}
            }
        },
        {
            ControlScheme.ARROWS, new Dictionary<Direction, KeyCode>
            {
                {Direction.UP, KeyCode.UpArrow},
                {Direction.DOWN, KeyCode.DownArrow},
                {Direction.LEFT, KeyCode.LeftArrow},
                {Direction.RIGHT, KeyCode.RightArrow}
            }
        },
        {
            ControlScheme.IJKL, new Dictionary<Direction, KeyCode>
            {
                {Direction.UP, KeyCode.I},
                {Direction.DOWN, KeyCode.K},
                {Direction.LEFT, KeyCode.J},
                {Direction.RIGHT, KeyCode.L}
            }
        }
    };

    #endregion

    #region Enums

    public enum ControlScheme { WASD, ARROWS, IJKL}
    public enum Direction { UP, DOWN, LEFT, RIGHT}
    public enum ShopItems { BASIC, FIRE, ICE, VOID, SPRINKLER, FERTILIZER, WATER, SICLE}
    public enum BulletType { BASIC, FIRE, ICE, VOID }
    public enum Phase { DAY, NIGHT}
    public enum ColorBlindMode { Normal, Protanope, Deuteranope}

    #endregion

    public float waterLevel = 100;
    public int currentLevel = 1;
    public int questsRequired = 5;
    public int questsCompleted = 0;
    public int money = 200;
    public int dayTimer = 900;
    public int dayTimerConstant = 900;
    public int waveNumber = 1;
    public int basicPlantsHarvested = 0;
    public int firePlantsHarvested = 0;
    public int icePlantsHarvested = 0;
    public int voidPlantsHarvested = 0;
    public int totalWaveEnemies = 0;
    public int spawnCount = 0;
    public int currentNumQuests = 0;
    public const int maxPlantLevel = 3;
    public ShopItems currentShopSelection = ShopItems.BASIC;
    public Phase currentPhase = Phase.DAY;
    public bool gameStarted = false;
    public bool gameOver = false;
    public bool pauseGame = false;
    public bool placingUpgrade = false;
    public bool wateringCanSelected = false;
    public bool SicleSelected = false;
    public bool purchasedWaterEfficiency = false;
    public bool purchasedBasicUpgrade = false;
    public bool purchasedFireUpgrade = false;
    public bool purchasedIceUpgrade = false;
    public bool purchasedVoidUpgrade = false;
    public bool completedTutorial = false;
    public ControlScheme currentControls = ControlScheme.WASD;
    public ColorBlindMode BlindMode = ColorBlindMode.Normal;
    public GameObject pauseWindow;
    public GameObject Objective1;
    public GameObject Objective2;
    public GameObject Objective3;

    #endregion

    #region Singleton

    // create variable for storing singleton that any script can access
    private static GameManager instance;

    // create GameManager
    private GameManager()
    {

    }

    // Property for Singleton
    public static GameManager Instance
    {
        get
        {
            // If the singleton does not exist
            if (instance == null)
            {
                // create and return it
                instance = new GameManager();
            }
            
            // otherwise, just return it
            return instance;
        }
    }

    #endregion

    #region Update

    public void Update()
    {
        #region Quest Complete Cheat

        if(Input.GetKeyUp(KeyCode.Q))
        {
            basicPlantsHarvested++;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            firePlantsHarvested++;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            icePlantsHarvested++;
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            voidPlantsHarvested++;
        }

        #endregion

        #region Get Objective References

        if (!Objective1)
        {
            if(GameObject.FindGameObjectWithTag("Objective1"))
            {
                pauseWindow = GameObject.FindGameObjectWithTag("PauseWindow");
                Objective1 = GameObject.FindGameObjectWithTag("Objective1");
                Objective2 = GameObject.FindGameObjectWithTag("Objective2");
                Objective3 = GameObject.FindGameObjectWithTag("Objective3");

                pauseWindow.GetComponent<Pause_Canvas_Controller>().BackToPauseMenu();
                pauseWindow.GetComponent<Pause_Canvas_Controller>().pauseWindow.SetActive(false);
            }
        }

        #endregion

        if(gameStarted)
        {
            #region End Game Check

            if (questsCompleted >= questsRequired)
            {
                gameOver = true;
                pauseGame = true;
            }

            #endregion
        }
        else
        {
            pauseGame = false;
        }

        if (!pauseGame && gameStarted)
        {
            #region Day Night Phase

            if (currentPhase == Phase.DAY)
            {
                dayTimer--;

                if (dayTimer <= 0)
                {
                    if (currentPhase == Phase.DAY)
                    {
                        currentPhase = Phase.NIGHT;
                    }
                    else if (currentPhase == Phase.NIGHT)
                    {
                        currentPhase = Phase.DAY;
                    }
                }
            }

            #endregion
        }

        #region Colorblind Modes

        if(Input.GetKeyUp(KeyCode.F1))
        {
            BlindMode = ColorBlindMode.Normal;
        }

        if (Input.GetKeyUp(KeyCode.F2))
        {
            BlindMode = ColorBlindMode.Protanope;
        }

        if (Input.GetKeyUp(KeyCode.F3))
        {
            BlindMode = ColorBlindMode.Deuteranope;
        }

        #endregion
    }

    #endregion

    #region Public Methods

        #region Start Level

        public void StartLevel()
        {
            questsCompleted = 0;
            gameStarted = true;

            if (currentLevel == 1)
            {
                questsRequired = 5;
            }
            else
            {
                basicPlantsHarvested = 0;
                firePlantsHarvested = 0;
                icePlantsHarvested = 0;
                voidPlantsHarvested = 0;
                currentNumQuests = 0;
                gameOver = false;
                pauseGame = false;
                placingUpgrade = false;
                purchasedFireUpgrade = false;
                purchasedIceUpgrade = false;
                purchasedVoidUpgrade = false;
                purchasedWaterEfficiency = false;
                dayTimer = 900;
                currentPhase = Phase.DAY;
                waveNumber = 1;
                questsRequired += Random.Range(2, 5);
            }
        }

        #endregion

        #region Next Level
    
        public void NextLevel()
        {
            basicPlantsHarvested = 0;
            firePlantsHarvested = 0;
            icePlantsHarvested = 0;
            voidPlantsHarvested = 0;
            currentNumQuests = 0;
            gameOver = false;
            pauseGame = false;
            placingUpgrade = false;
            purchasedFireUpgrade = false;
            purchasedIceUpgrade = false;
            purchasedVoidUpgrade = false;
            purchasedWaterEfficiency = false;
            dayTimer = 900;
            currentPhase = Phase.DAY;
            waveNumber = 1;
            gameStarted = false;
            SceneManager.LoadScene("Map 1");
        }

        #endregion

        #region Main Menu

        public void MainMenu()
        {
            basicPlantsHarvested = 0;
            firePlantsHarvested = 0;
            icePlantsHarvested = 0;
            voidPlantsHarvested = 0;
            gameOver = false;
            pauseGame = false;
            placingUpgrade = false;
            purchasedFireUpgrade = false;
            purchasedIceUpgrade = false;
            purchasedVoidUpgrade = false;
            purchasedWaterEfficiency = false;
            money = 200;
            dayTimer = 900;
            currentPhase = Phase.DAY;
            waveNumber = 1;
            currentLevel = 1;
            currentShopSelection = GameManager.ShopItems.BASIC;
            gameStarted = false;
        }

        #endregion

    #endregion
}