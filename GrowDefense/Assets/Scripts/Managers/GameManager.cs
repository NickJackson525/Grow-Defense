using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    #region Level Dictionary

    public Dictionary<Level, Dictionary<LevelFeatures, int>> Levels = new Dictionary<Level, Dictionary<LevelFeatures, int>>()
    {
        {
            Level.ONE, new Dictionary<LevelFeatures, int>
            {
                {LevelFeatures.Ladybug, 1},
                {LevelFeatures.NEXTENEMY, 0},
                {LevelFeatures.basicPlantsRequired, 5},
                {LevelFeatures.firePlantsRequired, 5},
                {LevelFeatures.icePlantsRequired, 5},
                {LevelFeatures.voidPlantsRequired, 5}
            }
        },
        {
            Level.TWO, new Dictionary<LevelFeatures, int>
            {
                {LevelFeatures.Ladybug, 1},
                {LevelFeatures.NEXTENEMY, 0},
                {LevelFeatures.basicPlantsRequired, 5},
                {LevelFeatures.firePlantsRequired, 5},
                {LevelFeatures.icePlantsRequired, 5},
                {LevelFeatures.voidPlantsRequired, 0}
            }
        },
        {
            Level.THREE, new Dictionary<LevelFeatures, int>
            {
                {LevelFeatures.Ladybug, 1},
                {LevelFeatures.NEXTENEMY, 0},
                {LevelFeatures.basicPlantsRequired, 5},
                {LevelFeatures.firePlantsRequired, 5},
                {LevelFeatures.icePlantsRequired, 5},
                {LevelFeatures.voidPlantsRequired, 5}
            }
        }
    };

    #endregion

    #region Quest Dictionary

    public Dictionary<QuestType, Dictionary<QuestFeatures, int>> quests = new Dictionary<QuestType, Dictionary<QuestFeatures, int>>()
    {
        {
            QuestType.onePlant, new Dictionary<QuestFeatures, int>
            {
                {QuestFeatures.basicsRequired, 1},
                {QuestFeatures.fireRequired, 0},
                {QuestFeatures.iceRequired, 5},
                {QuestFeatures.voidRequired, 5}
            }
        },
        {
            QuestType.twoPlants, new Dictionary<QuestFeatures, int>
            {
                {QuestFeatures.basicsRequired, 1},
                {QuestFeatures.fireRequired, 0},
                {QuestFeatures.iceRequired, 5},
                {QuestFeatures.voidRequired, 5}
            }
        },
        {
            QuestType.threePlants, new Dictionary<QuestFeatures, int>
            {
                {QuestFeatures.basicsRequired, 1},
                {QuestFeatures.fireRequired, 0},
                {QuestFeatures.iceRequired, 5},
                {QuestFeatures.voidRequired, 5}
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
    public enum Level { ONE, TWO, THREE, FOUR}
    public enum LevelFeatures { Ladybug, NEXTENEMY, basicPlantsRequired, firePlantsRequired, icePlantsRequired, voidPlantsRequired}
    public enum QuestType { onePlant, twoPlants, threePlants}
    public enum QuestFeatures { basicsRequired, fireRequired, iceRequired, voidRequired}

    #endregion

    public float waterLevel = 100;
    public int questsRequired = 5;
    public int questsCompleted = 0;
    public int money = 200;
    public int dayTimer = 900;
    public int dayTimerConstant = 900;
    public int waveNumber = 1;
    public int basicPlantsGrown = 0;
    public int firePlantsGrown = 0;
    public int icePlantsGrown = 0;
    public int voidPlantsGrown = 0;
    public int basicPlantsRequired = 5;
    public int firePlantsRequired = 5;
    public int icePlantsRequired = 5;
    public int voidPlantsRequired = 5;
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
    public Level currentLevel;
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

        if (!pauseGame && gameStarted)
        {
            #region End Game Check

            if ((basicPlantsGrown >= basicPlantsRequired) && (firePlantsGrown >= firePlantsRequired) && (icePlantsGrown >= icePlantsRequired) && (voidPlantsGrown >= voidPlantsRequired))
            {
                gameOver = true;
            }

            #endregion

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

    public void StartLevel(Level nextLevel)
    {
        basicPlantsRequired = Levels[nextLevel][LevelFeatures.basicPlantsRequired];
        firePlantsRequired = Levels[nextLevel][LevelFeatures.firePlantsRequired];
        icePlantsRequired = Levels[nextLevel][LevelFeatures.icePlantsRequired];
        voidPlantsRequired = Levels[nextLevel][LevelFeatures.voidPlantsRequired];
        gameStarted = true;
    }

    #endregion
}