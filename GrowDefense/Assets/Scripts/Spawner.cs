using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Variables

    public GameObject bug1;
    public int cooldown = 250;
    public int cooldownConst = 250;
    public int spawnCount = 0;
    public int spawnRateIncrease = 10;
    int spawnReset = 5;
    int initialSpawnCountDown = 240;

    #endregion

    #region Start

    // Use this for initialization
    void Start ()
    {
		
	}

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {
        cooldown--;

        if (initialSpawnCountDown > 0)
        {
            initialSpawnCountDown--;
        }

        if(cooldown <= 0 && initialSpawnCountDown == 0)
        {
            Instantiate(bug1, transform.position, transform.rotation);
            cooldown = cooldownConst;
            spawnCount++;
        }

        if((spawnCount == spawnReset) && (cooldownConst > 10))
        {
            cooldownConst -= spawnRateIncrease;
            spawnCount = 0;
        }
	}

    #endregion
}
