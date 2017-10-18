using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Game_Manager
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

    public enum ControlScheme { WASD, ARROWS, IJKL}
    public enum Direction { UP, DOWN, LEFT, RIGHT}
    public enum PlantType { FIRE, ICE, VOID }
    public enum BulletType { FIRE, ICE, VOID }
    public enum Phase { DAY, NIGHT}
    public float waterLevel = 100;
    public int money = 200;
    public int dayTimer = 900;
    public int dayTimerConstant = 900;
    public int waveNumber = 1;
    public int firePlantsGrown = 0;
    public int icePlantsGrown = 0;
    public int voidPlantsGrown = 0;
    public int firePlantsRequired = 5;
    public int icePlantsRequired = 5;
    public int voidPlantsRequired = 5;
    public const int maxPlantLevel = 3;
    public PlantType currentPlantSelection = PlantType.FIRE;
    public Phase currentPhase = Phase.DAY;
    public bool gameOver = false;
    public Game_Manager.ControlScheme currentControls = Game_Manager.ControlScheme.WASD;

    #endregion

    #region Singleton

    // create variable for storing singleton that any script can access
    private static Game_Manager instance;

    // create GameManager
    private Game_Manager()
    {

    }

    // Property for Singleton
    public static Game_Manager Instance
    {
        get
        {
            // If the singleton does not exist
            if (instance == null)
            {
                // create and return it
                instance = new Game_Manager();
            }
            
            // otherwise, just return it
            return instance;
        }
    }

    #endregion

    #region Update

    public void Update()
    {
        if((firePlantsGrown >= firePlantsRequired) && (icePlantsGrown >= icePlantsRequired) && (voidPlantsGrown >= voidPlantsRequired))
        {
            gameOver = true;
        }

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
    }

    #endregion
}
