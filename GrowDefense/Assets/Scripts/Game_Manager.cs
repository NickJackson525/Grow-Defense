using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Game_Manager
{
    #region Variables

    public enum PlantType { FIRE, ICE, VOID }
    public enum Phase { DAY, NIGHT}
    public float waterLevel = 100;
    public int money = 200;
    public int dayTimer = 900;
    public int dayTimerConstant = 900;
    public int waveNumber = 1;
    public const int maxPlantLevel = 3;
    public PlantType currentPlantSelection = PlantType.FIRE;
    public Phase currentPhase = Phase.DAY;

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

    public void Update()
    {
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
}
